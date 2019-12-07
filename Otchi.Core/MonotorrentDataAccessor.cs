using System.IO;
using System.Threading.Tasks;
using MonoTorrent;
using MonoTorrent.Client.PieceWriters;
using Otchi.Ebml.Parsers;

namespace Otchi.Core
{
    public class MonotorrentDataAccessor: IParserDataAccessor
    {
        private readonly IPieceWriter _writer;
        private TorrentFile? _torrentFile;

        public MonotorrentDataAccessor(IPieceWriter writer)
        {
            _writer = writer;
        }

        public async Task<int> ReadAsync(byte[] buffer, int bufferOffset, int count, long offset)
        {
            if (_writer == null)
                throw new InvalidDataException("Writer not initialized");
            if (_torrentFile == null)
                throw new InvalidDataException("Torrent file not initialized");

            Position = offset + count;
            return await Task.Run(() => _writer.Read(_torrentFile, offset, buffer, bufferOffset, count));
        }

        public async Task<int> ReadAsync(byte[] buffer, int bufferOffset, int count)
        {
            return await ReadAsync(buffer, bufferOffset, count, Position);
        }

        public long Position { get; set; }
        public bool Done => Position >= Length;
        public long Length
        {
            get
            {
                if (_torrentFile == null)
                    throw new InvalidDataException("Torrent File not Initialized");
                return _torrentFile.Length;
            }
        }

        public void SetTorrentFile(TorrentFile file)
        {
            _torrentFile = file;
        }
    }
}