using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent.Client;
using Otchi.Ebml;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Matroska.Tags;
using Otchi.Matroska.Factories;

namespace Otchi.Core
{
    public enum MatroskaPlayerStatus
    {
        LoadingMetadata,
        LoadingMovieDetails,
        Playable
    }

    public class MatroskaPlayer
    {
        private SortedSet<long> _hashedPieces = new SortedSet<long>();
        private readonly MonoTorrent.Client.TorrentManager _manager;
        private EbmlParser? _parser;
        private EbmlDocument? _document;
        private readonly SemaphoreSlim _documentCreateSemaphore = new SemaphoreSlim(1, 1);
        private MonotorrentDataAccessor _dataAccessor;
        public MatroskaPlayerStatus PlayerStatus { get; private set; } = MatroskaPlayerStatus.LoadingMetadata;
        private bool _isIndexing = false;
        private object _indexLock = new object();

        private List<Dictionary<long, EbmlElementFactory>> dictList = new List<Dictionary<long, EbmlElementFactory>>
        {
            EbmlFactories.AllEbmlHeadFactories,
            MatroskaFactories.SegmentInformationFactories,
            MatroskaFactories.AttachmentFactories,
            MatroskaFactories.ChapterFactories,
            MatroskaFactories.CueingDataFactories,
            MatroskaFactories.MatroskaSegmentFactories,
            MatroskaFactories.MetaSeekInformationFactories,
            MatroskaFactories.TaggingFactories,
            MatroskaFactories.TrackFactories
        };

        private Dictionary<long, EbmlElementFactory> ElementFactories => EbmlFactories.Merge(dictList);


        public MatroskaPlayer(MonoTorrent.Client.TorrentManager manager, MonotorrentDataAccessor dataAccessor)
        {
            _manager = manager;
            _dataAccessor = dataAccessor;
        }

        public async Task OnPieceHashed(object sender, PieceHashedEventArgs eventArgs)
        {
            if (!eventArgs.HashPassed) return;
            _hashedPieces.Add(eventArgs.PieceIndex);

            if (_parser is null) return;
            await GetDoc();

            if (_document?.Body is null || _document?.Head is null) return;

            await TryIndexDocument(eventArgs.PieceIndex);
        }

        private async Task TryIndexDocument(int index)
        {
            if (_parser is null) throw new InvalidOperationException("Can't parse document if parser has not been set yet");

            lock(_indexLock)
            {
                if (_isIndexing || !_hashedPieces.Contains(index)) return;
                _isIndexing = true;
            }
            Console.WriteLine("Entering");

            try
            {
                if (PlayerStatus == MatroskaPlayerStatus.Playable) return;
                Console.WriteLine($"Flushing {index}");
                await _manager.Engine.DiskManager.FlushAsync(_manager.Torrent, index).ConfigureAwait(false);

                Cues? cues = null;
                try
                {
                    cues = await _document!.Body!.TryGetChild<Cues>(_parser);
                }
                catch (DecodeException exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine(_document);
                }
                if (cues != null)
                {
                    await cues.Decode(_parser);
                    if (cues.Decoded)
                    {
                        PlayerStatus = MatroskaPlayerStatus.Playable;
                        Console.WriteLine("Ready to start");
                    }
                }
                else
                {

                    if (await _document.Body.TryGetChild<SeekHead>(_parser) is {} seekMaster)
                    {
                        await seekMaster.Decode(_parser);
                        if (seekMaster.Decoded)
                        {
                            foreach (Seek seek in seekMaster.Values)
                            {
                                if (seek.SeekId == (ulong)MatroskaIds.CuesId.Size)
                                {
                                    var element = await _parser.ParseElementAt((long)seek.SeekPosition!);
                                    Console.WriteLine(element);
                                }
                            }
                        }
                    }
                }
            }
            catch (FileNotLoadedException) { Console.WriteLine("Failed to load"); }
            catch (InvalidIdException) { Console.WriteLine("Invalid ID"); }
            finally
            {
                Console.WriteLine("Exiting");
                _isIndexing = false;
                await TryIndexDocument(index + 1);
            }
        }

        private async Task GetDoc()
        {
            if (_parser == null) throw new InvalidDataException("Parser not initialized");
            await _documentCreateSemaphore.WaitAsync();
            try
            {
                // In the try block to be able to release the semaphore
                if (_document != null) return;
                _document = await _parser.ParseDocument(false);
                await _document?.Head?.Decode(_parser);
            }
            catch (InvalidEbmlDocException)
            {
            }
            finally
            {
                _documentCreateSemaphore.Release(1);
            }
        }


        public async Task OnTorrentLoaded(object sender, TorrentStateChangedEventArgs e)
        {
            _parser = new EbmlParser(_dataAccessor, ElementFactories);
            await GetDoc();
            PlayerStatus = MatroskaPlayerStatus.LoadingMovieDetails;
        }
    }
}