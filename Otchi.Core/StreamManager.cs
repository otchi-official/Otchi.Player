using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using NLog;
using Otchi.Core.EventArgs;

namespace Otchi.Core
{
    public class StreamManager : IDisposable
    {
        public StreamManager(Uri magnetUrl)
        {
            if (magnetUrl is null) throw new ArgumentNullException(nameof(magnetUrl));

            var settings = new EngineSettings
            {
                SavePath = _saveDirectory,
                ListenPort = Port
            };

            var torrentDefaults = new TorrentSettings();
            _engine = new ClientEngine(settings);

            if (!Directory.Exists(_saveDirectory))
                Directory.CreateDirectory(_saveDirectory);

            var magnet = MagnetLink.Parse(magnetUrl.AbsoluteUri);
            _torrentManager = new TorrentManager(magnet, _saveDirectory, torrentDefaults, _saveDirectory);
            _torrentManager.PieceHashed += OnPieceHashed;
            _torrentManager.TorrentStateChanged += OnStateChanged;

            TorrentError += OnError;
        }

        public async Task Start()
        {
            await _startSemaphore.WaitAsync().ConfigureAwait(false);

            try
            {
                if (_torrentManager.State != TorrentState.Stopped)
                {
                    Logger.Warn($"Start called on torrent while its state is: {_torrentManager.State}");
                    return;
                }

                await LoadDhtNodes().ConfigureAwait(false);

                if (!_engine.Torrents.Contains(_torrentManager))
                    await _engine.Register(_torrentManager).ConfigureAwait(false);

                if (_torrentManager.HasMetadata)
                    await LoadFastResumeData().ConfigureAwait(false);
                else
                    TorrentMetadataLoaded += OnMetadataLoaded;

                await _torrentManager.StartAsync().ConfigureAwait(false);
                Logger.Info("Started torrent download.");
            }
            finally
            {
                _startSemaphore.Release(1);
            }
        }

        #region Fields

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private const int Port = 6600;
        private readonly ClientEngine _engine;
        private readonly TorrentManager _torrentManager;
        private SlidingWindowPicker? _picker;
        private bool _loaded;
        private DownloadProgress? _progress;
        private readonly SemaphoreSlim _startSemaphore = new SemaphoreSlim(1, 1);

        private readonly List<int> _hashedPieces = new List<int>();

        #endregion

        #region Properties

        public string Name => _torrentManager.Torrent.Name;
        public string FullPath => Path.Combine(_saveDirectory, Name);

        public DownloadProgress? Progress
        {
            get => _progress;
            private set
            {
                if (_progress != null) _progress.DownloadProgressed -= OnDownloadProgressed;
                _progress = value;
                if (_progress == null) return;

                _progress.DownloadProgressed += OnDownloadProgressed;
            }
        }

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

        #region OnEvent

        private async void OnMetadataLoaded(object sender, TorrentStateChangedEventArgs e)
        {
            Debug.Assert(_torrentManager.HasMetadata, "Metadata was not found");
            Debug.Assert(_torrentManager.Torrent != null, "_torrentManager.Torrent != null");
            Logger.Trace("Metadata found, stopping to load fast resume");

            await _torrentManager.StopAsync().ConfigureAwait(false);

            Progress = new DownloadProgress(_torrentManager.Torrent, new ReadOnlyCollection<int>(_hashedPieces));
            await LoadPicker().ConfigureAwait(false);

            TorrentMetadataLoaded -= OnMetadataLoaded;
            await _torrentManager.StartAsync().ConfigureAwait(false);
        }

        private void OnStateChanged(object sender, TorrentStateChangedEventArgs e)
        {
            Logger.Info($"Torrent State changed from: {e.OldState} to: {e.NewState}");

            if (e.OldState == TorrentState.Metadata && e.NewState != TorrentState.Error)
                TorrentMetadataLoaded.Invoke(this, e);
            switch (e.NewState)
            {
                case TorrentState.Error:
                    TorrentError.Invoke(this, e);
                    break;
                case TorrentState.Stopped:
                    TorrentStopped.Invoke(this, e);
                    break;
                case TorrentState.Paused:
                    TorrentPaused.Invoke(this, e);
                    break;
                case TorrentState.Starting:
                    TorrentStarting.Invoke(this, e);
                    break;
                case TorrentState.Downloading:
                    TorrentDownloading.Invoke(this, e);
                    break;
                case TorrentState.Seeding:
                    TorrentSeeding.Invoke(this, e);
                    break;
                case TorrentState.Hashing:
                    TorrentHashing.Invoke(this, e);
                    break;
                case TorrentState.HashingPaused:
                    TorrentHashingPaused.Invoke(this, e);
                    break;
                case TorrentState.Stopping:
                    TorrentStopping.Invoke(this, e);
                    break;
                case TorrentState.Metadata:
                    TorrentMetadata.Invoke(this, e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(e));
            }
        }

        private void OnError(object sender, TorrentStateChangedEventArgs e)
        {
            Logger.Error(_torrentManager.Error.Exception);
            Logger.Error(_torrentManager.Error.Exception.Source);
            Logger.Error(_torrentManager.Error.Reason);
        }

        private async void OnPieceHashed(object sender, PieceHashedEventArgs e)
        {
            if (!e.HashPassed) return;

            await _engine.DiskManager.FlushAsync(_torrentManager.Torrent, e.PieceIndex).ConfigureAwait(false);
            _hashedPieces.Add(e.PieceIndex);
            Progress?.OnPieceRegistered(new PieceRegisteredEventArgs(e.PieceIndex));
        }

        private void OnDownloadProgressed(object sender, DownloadProgressedEventArgs e)
        {
            Debug.Assert(Progress != null, "Progress != null");
            lock (StreamLoaded)
            {
                if (_loaded || e.ModifiedRange.StartIndex != 0 || e.ModifiedRange.Count < 10) return;

                Logger.Info("Stream Loaded");
                StreamLoaded(this, new StreamLoadedEventArgs());
                _loaded = true;
            }
        }

        #endregion

        #region Initializing

        private async Task LoadPicker()
        {
            if (!_torrentManager.HasMetadata || _torrentManager.State != TorrentState.Stopped)
                throw new InvalidDataException("Torrent Manager is in an invalid state");

            _picker = new SlidingWindowPicker(new StandardPicker()) {HighPrioritySetSize = 5, HighPrioritySetStart = 0};
            await _torrentManager.ChangePickerAsync(_picker).ConfigureAwait(false);
        }

        private async Task LoadFastResumeData()
        {
            try
            {
                var fastResumeData = await File.ReadAllBytesAsync(FastResumeFile).ConfigureAwait(false);
                var fastResume = BEncodedValue.Decode<BEncodedDictionary>(fastResumeData);
                Logger.Trace("Fast resume data found initializing torrent with existing data.");
                if (fastResume.ContainsKey(_torrentManager.InfoHash.ToHex()))
                {
                    var fastResumeForTorrent =
                        new FastResume((BEncodedDictionary) fastResume[_torrentManager.InfoHash.ToHex()]);
                    _torrentManager.LoadFastResume(fastResumeForTorrent);
                }
            }
            catch (IOException)
            {
                Logger.Trace("No fast resume data found starting fresh torrent.");
            }
        }

        private async Task LoadDhtNodes()
        {
            using var dhtEngine = new DhtEngine(new IPEndPoint(IPAddress.Any, Port));
            await _engine.RegisterDhtAsync(dhtEngine).ConfigureAwait(false);

            var nodes = Array.Empty<byte>();
            try
            {
                nodes = await File.ReadAllBytesAsync(DhtNodeFile).ConfigureAwait(false);
            }
            catch (IOException)
            {
                Logger.Trace("No existing dht nodes found, creating fresh engine.");
            }

            await _engine.DhtEngine.StartAsync(nodes).ConfigureAwait(false);
        }

        #endregion

        #region Closing

        public async Task ShutDown()
        {
            await _torrentManager.StopAsync().ConfigureAwait(false);
            Logger.Debug("Torrent Manager shut down");

            if (_torrentManager.HashChecked)
                await SaveFastResume().ConfigureAwait(false);

            await SaveDhtNodes().ConfigureAwait(false);
            _engine.Dispose();
        }

        private async Task SaveFastResume()
        {
            var fastResume = new BEncodedDictionary
            {
                {_torrentManager.Torrent.InfoHash.ToHex(), _torrentManager.SaveFastResume().Encode()}
            };

            // TODO: read from file
            await File.WriteAllBytesAsync(FastResumeFile, fastResume.Encode()).ConfigureAwait(false);
        }

        private async Task SaveDhtNodes()
        {
            var nodes = await _engine.DhtEngine.SaveNodesAsync().ConfigureAwait(false);
            await File.WriteAllBytesAsync(DhtNodeFile, nodes).ConfigureAwait(false);
        }

        #endregion

        #region Disposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!dispose) return;

            _engine.Dispose();
            _torrentManager.Dispose();
        }

        #endregion
    }
}
