using System.IO;
using System.Threading.Tasks;

namespace Otchi.Ebml.Parsers
{
    public class FileDataAccessor: IParserDataAccessor
    {
        private readonly FileStream _fileStream;
        public long Position {
            get => _fileStream.Position;
            set => _fileStream.Seek(value, SeekOrigin.Begin);
        }
        public bool Done => Position >= Length;
        public long Length => _fileStream.Length;

        public async Task<int> ReadAsync(byte[] buffer, int bufferOffset, int count, long offset)
        {
            _fileStream.Seek(offset, SeekOrigin.Begin);
            return await _fileStream.ReadAsync(buffer, bufferOffset, count).ConfigureAwait(false);
        }

        public async Task<int> ReadAsync(byte[] buffer, int bufferOffset, int count)
        {
            return await ReadAsync(buffer, bufferOffset, count, Position).ConfigureAwait(false);
        }

        public FileDataAccessor(string path)
        {
            _fileStream = File.OpenRead(path);
        }
    }
}