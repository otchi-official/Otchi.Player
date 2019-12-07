using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent;
using MonoTorrent.BEncoding;
using MonoTorrent.Client;
using MonoTorrent.Client.PiecePicking;
using MonoTorrent.Client.PieceWriters;
using MonoTorrent.Dht;
using Otchi.Ebml.Factories;
using Console = System.Console;
using Path = System.IO.Path;

namespace Otchi.Core
{
    public class TorrentManager
    {
        private const int Port = 6600;

        private readonly ClientEngine _engine;
        private readonly MonoTorrent.Client.TorrentManager _manager;
        private readonly string _saveDirectory = Directory.GetCurrentDirectory();
        private string FastResumeFile => Path.Combine(_saveDirectory, "fastResume.data");
        private string DhtNodeFile => Path.Combine(_saveDirectory, "DhtNodes");

        private EventHandler<TorrentStateChangedEventArgs>? _onMetadataLoadedListener;
        private readonly MatroskaPlayer _matroskaPlayer;

        private event EventHandler<TorrentStateChangedEventArgs> MetadataLoaded = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentError = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentStopped = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentPaused = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentStarting = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentDownloading = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentSeeding = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentHashing = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentHashingPaused = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentStopping = delegate { };
        private event EventHandler<TorrentStateChangedEventArgs> TorrentMetadata = delegate { };
        private readonly MonotorrentDataAccessor _dataAccessor;

        public TorrentManager(string magnetUrl, string downloadLocation)
        {
            var settings = new EngineSettings
            {
                SavePath = downloadLocation,
                ListenPort = Port
            };

            var torrentDefaults = new TorrentSettings();
            var writer = new DiskWriter();
            _dataAccessor = new MonotorrentDataAccessor(writer);
            _engine = new ClientEngine(settings, writer);

            if (!Directory.Exists(downloadLocation))
                Directory.CreateDirectory(downloadLocation);

            var magnet = MagnetLink.Parse(magnetUrl);
            _manager = new MonoTorrent.Client.TorrentManager(magnet, downloadLocation, torrentDefaults, downloadLocation);
            _manager.PieceHashed += async (sender, eventArgs) => await _matroskaPlayer.OnPieceHashed(sender, eventArgs);
            _manager.TorrentStateChanged += delegate (object sender, TorrentStateChangedEventArgs args) { Console.WriteLine(args.NewState); };
            _matroskaPlayer = new MatroskaPlayer(_manager, _dataAccessor);
            TorrentError += OnError;
        }

        public async Task Start()
        {
            if (_manager.State != TorrentState.Stopped)
            {
                Console.WriteLine("Can't start a running manager");
                return;
            }

            await RegisterDht();
            await _engine.Register(_manager);

            if (_manager.HasMetadata)
            {
                await LoadFastResumeData();
                await _manager.StartAsync();
            }
            else
            {
                _onMetadataLoadedListener = async (sender, eventArgs) => await OnMetadataLoaded(sender, eventArgs);
                _manager.TorrentStateChanged += OnStateChanged;
                MetadataLoaded += _onMetadataLoadedListener;
                await _manager.StartAsync();
            }
        }

        private void OnStateChanged(object sender, TorrentStateChangedEventArgs e)
        {
            if (e.OldState == TorrentState.Metadata && e.NewState != TorrentState.Error)
            {
                MetadataLoaded.Invoke(sender, e);
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

        private async Task OnMetadataLoaded(object sender, TorrentStateChangedEventArgs e)
        {
            Debug.Assert(_manager.HasMetadata, "Metadata was not found");
            Console.WriteLine("Metadata found, stopping to load fast resume");
            await _manager.StopAsync();
            await ChangePicker();
            await LoadFastResumeData();

            _dataAccessor.SetTorrentFile(_manager.Torrent.Files.First());
            await _matroskaPlayer.OnTorrentLoaded(sender, e);

            if (_onMetadataLoadedListener != null)
            {
                MetadataLoaded -= _onMetadataLoadedListener;
                _onMetadataLoadedListener = null;
            }

            await _manager.StartAsync();
        }

        private void OnError(object sender, TorrentStateChangedEventArgs e)
        {
            Console.WriteLine(_manager.Error.Exception);
            Console.WriteLine(_manager.Error.Exception.Source);
            Console.WriteLine(_manager.Error.Reason);
        }

        private async Task ChangePicker()
        {
            if (!_manager.HasMetadata || _manager.State != TorrentState.Stopped)
                throw new InvalidDataException("Torrent Manager is in an invalid state");

            var picker = new SlidingWindowPicker(new StandardPicker()) { HighPrioritySetStart = 0 };
            await _manager.ChangePickerAsync(picker);
        }

        private async Task LoadFastResumeData()
        {
            try
            {
                var fastResumeData = await File.ReadAllBytesAsync(FastResumeFile);
                var fastResume = BEncodedValue.Decode<BEncodedDictionary>(fastResumeData);
                Console.WriteLine("Fast resume data found initializing torrent with existing data.");
                if (fastResume.ContainsKey(_manager.InfoHash.ToHex()))
                {
                    var fastResumeForTorrent = new FastResume((BEncodedDictionary)fastResume[_manager.InfoHash.ToHex()]);
                    _manager.LoadFastResume(fastResumeForTorrent);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No fast resume data found starting fresh torrent.");
            }
        }

        private async Task RegisterDht()
        {
            var dhtEngine = new DhtEngine(new IPEndPoint(IPAddress.Any, Port));
            await _engine.RegisterDhtAsync(dhtEngine);

            var nodes = Array.Empty<byte>();
            try
            {
                nodes = await File.ReadAllBytesAsync(DhtNodeFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No existing dht nodes found, creating fresh engine.");
            }

            await _engine.DhtEngine.StartAsync(nodes);
        }

        public async Task ShutDown()
        {
            await _manager.StopAsync();

            Debug.Assert(_manager.State == TorrentState.Stopped, "manager not stopped");
            Console.WriteLine($"Stopped {_manager.Torrent.Name}, current State: {_manager.State}");

            if (_manager.HashChecked)
                await SaveFastResume();

            await SaveDhtNodes();
            _engine.Dispose();
        }

        private async Task SaveFastResume()
        {
            var fastResume = new BEncodedDictionary
            {
                {_manager.Torrent.InfoHash.ToHex(), _manager.SaveFastResume().Encode()}
            };
            // TODO: read from file
            await File.WriteAllBytesAsync(FastResumeFile, fastResume.Encode());
        }

        private async Task SaveDhtNodes()
        {
            var nodes = await _engine.DhtEngine.SaveNodesAsync();
            await File.WriteAllBytesAsync(DhtNodeFile, nodes);
        }
    }
}