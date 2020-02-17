using System;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent.Client;
using NLog;
using Otchi.Core.EventArgs;
using Otchi.Ebml;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Matroska.Tags;

namespace Otchi.Core
{
    public class Indexer
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public Cues? Cues { get; private set; }
        private EbmlParser? _parser;
        private EbmlDocument? _document;

        public event EventHandler<CuesLoadedEventArgs> CuesLoaded = delegate { };
        
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        
        public async void OnPieceHashed(object sender, PieceHashedEventArgs e)
        {
            if (Cues != null) return;
            await _semaphore.WaitAsync().ConfigureAwait(false);

            try
            {
                if (Cues != null || _parser is null) return;
                
                
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async void OnMetadataLoaded(object sender, TorrentStateChangedEventArgs e)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);

            try
            {
                if (_parser != null) return;
                var torrentManager = (StreamManager) sender;
                if (torrentManager is null)
                {
                    Logger.Error("Failed to get Stream Manager");
                    return;
                }
                _parser = new EbmlParser(new FileDataAccessor(torrentManager.FullPath));
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<bool> TryIndex()
        {
            if (_document is null)
                try
                {
                    _document = await _parser.ParseDocument().ConfigureAwait(false);
                }
                catch (DecodeException e)
                {
                    Logger.Error($"Failed to load document: {e.Message}");
                }

            if (_document is null) return false;
            
            
            
            return true;
        }
    }
}