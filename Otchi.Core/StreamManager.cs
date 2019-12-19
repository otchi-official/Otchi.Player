using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent;
using MonoTorrent.BEncoding;
using MonoTorrent.Client;
using MonoTorrent.Client.PiecePicking;
using MonoTorrent.Dht;
using Otchi.Ebml;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Matroska.Factories;
using Otchi.Matroska.Tags;


namespace Otchi.Core
{

    public class StreamLoadedEventArgs : EventArgs
    {
    }

    public class StreamManager
    {
        private const int Port = 6600;
        private readonly ClientEngine _engine;
        private readonly TorrentManager _torrentManager;
        private SlidingWindowPicker? _picker;

        private readonly SortedSet<long> _hashedPieces = new SortedSet<long>();
        private readonly SortedSet<long> _requestedPieces = new SortedSet<long>();

        #region EBML

        private EbmlParser? _parser;
        private EbmlDocument? _document;
        private readonly List<Dictionary<long, EbmlElementFactory>> _dictList = new List<Dictionary<long, EbmlElementFactory>>
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

        private Dictionary<long, EbmlElementFactory> ElementFactories => EbmlFactories.Merge(_dictList);


        #endregion

        #region Events

        public event EventHandler<TorrentStateChangedEventArgs> TorrentMetadataLoaded = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentError = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentStopped = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentPaused = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentStarting = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentDownloading = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentSeeding = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentHashing = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentHashingPaused = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentStopping = delegate { };
        public event EventHandler<TorrentStateChangedEventArgs> TorrentMetadata = delegate { };
        public event EventHandler<StreamLoadedEventArgs> StreamLoaded = delegate { };

        #endregion

        #region Paths

        private readonly string _saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
        private string FastResumeFile => Path.Combine(_saveDirectory, "fastResume.data");
        private string DhtNodeFile => Path.Combine(_saveDirectory, "DhtNodes");

        #endregion

        #region Semaphores

        private readonly SemaphoreSlim _documentSemaphore = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _requestSemaphore = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _cuesSemaphore = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _seekHeadSemaphore = new SemaphoreSlim(1, 1);

        #endregion

        public StreamManager(string magnetUrl)
        {
            var settings = new EngineSettings
            {
                SavePath = _saveDirectory,
                ListenPort = Port
            };

            var torrentDefaults = new TorrentSettings();
            _engine = new ClientEngine(settings);

            if (!Directory.Exists(_saveDirectory))
                Directory.CreateDirectory(_saveDirectory);

            var magnet = MagnetLink.Parse(magnetUrl);
            _torrentManager = new TorrentManager(magnet, _saveDirectory, torrentDefaults, _saveDirectory);
            _torrentManager.PieceHashed += OnPieceHashed;
            _torrentManager.TorrentStateChanged += OnStateChanged;
            _torrentManager.TorrentStateChanged += (sender, args) => Console.WriteLine(args.NewState);
            TorrentError += OnError;
        }

        public async Task Start()
        {
            if (_torrentManager.State != TorrentState.Stopped)
                throw new InvalidOperationException("Object is not stopped");

            await LoadDhtNodes();
            await _engine.Register(_torrentManager);

            if (_torrentManager.HasMetadata)
            {
                await LoadFastResumeData();
            }
            else
            {
                TorrentMetadataLoaded += OnMetadataLoaded;
            }

            await _torrentManager.StartAsync();
        }

        #region OnEvent

        private async void OnPieceHashed(object sender, PieceHashedEventArgs e)
        {
            if (!e.HashPassed) return;
            // The piece request needs to access the same _hashed pieces resource
            Console.WriteLine($"Hashed piece {e.PieceIndex}");
            await _requestSemaphore.WaitAsync();
            try
            {
                _hashedPieces.Add(e.PieceIndex);
            }
            finally
            {
                _requestSemaphore.Release();
            }


            if (!_requestedPieces.Contains(e.PieceIndex)) return;

            await IndexStream(e.PieceIndex);
            _requestedPieces.Remove(e.PieceIndex);
        }

        private async void OnMetadataLoaded(object sender, TorrentStateChangedEventArgs e)
        {
            Debug.Assert(_torrentManager.HasMetadata, "Metadata was not found");
            Console.WriteLine("Metadata found, stopping to load fast resume");
            await _torrentManager.StopAsync();
            await LoadPicker();
            //await LoadFastResumeData();

            var dataAccessor = new FileDataAccessor(Path.Combine(_torrentManager.SavePath, _torrentManager.Torrent.Name));
            _parser = new EbmlParser(dataAccessor, ElementFactories);

            TorrentMetadataLoaded -= OnMetadataLoaded;

            _requestedPieces.Add(0);
            await _torrentManager.StartAsync();
        }

        private void OnStateChanged(object sender, TorrentStateChangedEventArgs e)
        {
            if (e.OldState == TorrentState.Metadata && e.NewState != TorrentState.Error)
            {
                TorrentMetadataLoaded.Invoke(sender, e);
            }
            switch (e.NewState)
            {
                case TorrentState.Error:
                    TorrentError.Invoke(sender, e);
                    break;
                case TorrentState.Stopped:
                    TorrentStopped.Invoke(sender, e);
                    break;
                case TorrentState.Paused:
                    TorrentPaused.Invoke(sender, e);
                    break;
                case TorrentState.Starting:
                    TorrentStarting.Invoke(sender, e);
                    break;
                case TorrentState.Downloading:
                    TorrentDownloading.Invoke(sender, e);
                    break;
                case TorrentState.Seeding:
                    TorrentSeeding.Invoke(sender, e);
                    break;
                case TorrentState.Hashing:
                    TorrentHashing.Invoke(sender, e);
                    break;
                case TorrentState.HashingPaused:
                    TorrentHashingPaused.Invoke(sender, e);
                    break;
                case TorrentState.Stopping:
                    TorrentStopping.Invoke(sender, e);
                    break;
                case TorrentState.Metadata:
                    TorrentMetadata.Invoke(sender, e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnError(object sender, TorrentStateChangedEventArgs e)
        {
            Console.WriteLine(_torrentManager.Error.Exception);
            Console.WriteLine(_torrentManager.Error.Exception.Source);
            Console.WriteLine(_torrentManager.Error.Reason);
        }

        #endregion

        #region Initializing

        private async Task LoadPicker()
        {
            if (!_torrentManager.HasMetadata || _torrentManager.State != TorrentState.Stopped)
                throw new InvalidDataException("Torrent Manager is in an invalid state");

            _picker = new SlidingWindowPicker(new StandardPicker()) { HighPrioritySetSize = 5, HighPrioritySetStart = 0 };
            await _torrentManager.ChangePickerAsync(_picker);
        }

        private async Task LoadFastResumeData()
        {
            try
            {
                var fastResumeData = await File.ReadAllBytesAsync(FastResumeFile);
                var fastResume = BEncodedValue.Decode<BEncodedDictionary>(fastResumeData);
                Console.WriteLine("Fast resume data found initializing torrent with existing data.");
                if (fastResume.ContainsKey(_torrentManager.InfoHash.ToHex()))
                {
                    var fastResumeForTorrent = new FastResume((BEncodedDictionary)fastResume[_torrentManager.InfoHash.ToHex()]);
                    _torrentManager.LoadFastResume(fastResumeForTorrent);
                }

            }
            catch (IOException)
            {
                Console.WriteLine("No fast resume data found starting fresh torrent.");
            }
        }

        private async Task LoadDhtNodes()
        {
            var dhtEngine = new DhtEngine(new IPEndPoint(IPAddress.Any, Port));
            await _engine.RegisterDhtAsync(dhtEngine);

            var nodes = Array.Empty<byte>();
            try
            {
                nodes = await File.ReadAllBytesAsync(DhtNodeFile);
            }
            catch (IOException)
            {
                Console.WriteLine("No existing dht nodes found, creating fresh engine.");
            }

            await _engine.DhtEngine.StartAsync(nodes);
        }

        #endregion

        #region Closing

        public async Task ShutDown()
        {
            await _torrentManager.StopAsync();
            Console.WriteLine("Torrent Manager shut down");

            if (_torrentManager.HashChecked)
                await SaveFastResume();

            await SaveDhtNodes();
            _engine.Dispose();
        }

        private async Task SaveFastResume()
        {
            var fastResume = new BEncodedDictionary
            {
                {_torrentManager.Torrent.InfoHash.ToHex(), _torrentManager.SaveFastResume().Encode()}
            };
            // TODO: read from file
            await File.WriteAllBytesAsync(FastResumeFile, fastResume.Encode());
        }

        private async Task SaveDhtNodes()
        {
            var nodes = await _engine.DhtEngine.SaveNodesAsync();
            await File.WriteAllBytesAsync(DhtNodeFile, nodes);
        }

        #endregion

        #region Document Indexing

        private async Task IndexStream(int pieceIndex)
        {
            Console.WriteLine($"Indexing {pieceIndex}");
            await _torrentManager.Engine.DiskManager.FlushAsync(_torrentManager.Torrent, pieceIndex)
                .ConfigureAwait(false);

            if (_document is null)
            {
                if (!await ParseDocument(pieceIndex))
                    return;
            }

            var cues = await ParseCues(pieceIndex);
            if (cues is null)
            {
                Console.WriteLine("Cues were null, but they probably shouldn't");
                return;
            }
            _picker!.HighPrioritySetStart = 0;
            StreamLoaded(this, new StreamLoadedEventArgs());
            Console.WriteLine(cues);
        }

        private async Task<bool> ParseDocument(int pieceIndex)
        {
            Debug.Assert(_parser != null, "Parser can not be null when trying to parse the document");
            await _documentSemaphore.WaitAsync();

            try
            {
                if (_document != null) return true;

                var document = _parser!.ParseDocument(false).Result;
                await document.Head.Decode(_parser);
                if (document.Head.Decoded)
                {
                    _document = document;
                }

                return true;
            }
            catch (DecodeException exception)
            {
                Console.WriteLine($"Failed to parse document: {exception}");
                await RequestPieceToIndex(pieceIndex + 1);
            }
            finally
            {
                _documentSemaphore.Release();
            }

            return false;
        }

        private async Task<Cues?> ParseCues(int pieceIndex)
        {
            Debug.Assert(_parser != null, "Parser can not be null at this point");
            if (_document?.Body == null)
                throw new InvalidOperationException("Document can not be null when trying to decode the cues");

            await _cuesSemaphore.WaitAsync();


            try
            {
                var cues = await _document.Body.TryGetChild<Cues>(_parser);
                await (cues?.Decode(_parser) ?? Task.CompletedTask);
                if (cues != null) return cues;
            }
            catch (DecodeException e)
            {
                Console.WriteLine($"Could not decode cues {e}");
                var cuesPos = await ParseCuesPosition(pieceIndex) + _document.Body.DataPosition;
                if (cuesPos is null) return null;
                try
                {
                    var cues = await _document.Body.DecodeChildAt(_parser, (long)cuesPos);
                    await (cues.Value?.Decode(_parser) ?? Task.FromResult<Cues?>(null));
                    if (cues.Value is null) throw new DecodeException();
                    return cues.Value as Cues;
                }
                catch (DecodeException exception)
                {
                    var pieceToGet = (int)(cuesPos / _torrentManager.Torrent.PieceLength);
                    if (pieceToGet == pieceIndex)
                        pieceToGet += 1;
                    Console.WriteLine($"Could not decode cues at {cuesPos}. Requesting piece {pieceToGet}. {exception}");
                    await RequestPieceToIndex(pieceToGet);
                }
            }
            finally
            {
                _cuesSemaphore.Release();
            }

            return null;
        }

        private async Task<long?> ParseCuesPosition(int pieceIndex)
        {
            Debug.Assert(_parser != null, "Parser can not be null at this point");
            if (_document?.Body == null)
                throw new InvalidOperationException("Document can not be null when trying to decode the cues");

            await _seekHeadSemaphore.WaitAsync();

            try
            {
                var seekHead = await _document.Body.TryGetChild<SeekHead>(_parser);
                await seekHead.Decode(_parser);
                Debug.Assert(seekHead.Decoded, "seek head not decoded");

                foreach (var child in seekHead)
                {
                    var seek = (Seek)child.Value;
                    if (seek.SeekId == (ulong)MatroskaIds.CuesId.Size)
                    {
                        return (long?)seek.SeekPosition;
                    }
                }
            }
            catch (DecodeException)
            {
                await RequestPieceToIndex(pieceIndex + 1);
            }
            finally
            {
                _seekHeadSemaphore.Release();
            }

            return null;
        }

        private async Task RequestPieceToIndex(int pieceIndex)
        {
            Console.WriteLine($"Requesting {pieceIndex}");
            var shouldIndex = false;
            await _requestSemaphore.WaitAsync();

            try
            {
                if (_hashedPieces.Contains(pieceIndex))
                    shouldIndex = true;
                else
                {
                    if (!_requestedPieces.Contains(pieceIndex))
                        _requestedPieces.Add(pieceIndex);
                    _picker!.HighPrioritySetStart = pieceIndex;
                }
            }
            finally
            {
                _requestSemaphore.Release();
            }

            if (shouldIndex)
                await IndexStream(pieceIndex);
        }

        #endregion


    }
}