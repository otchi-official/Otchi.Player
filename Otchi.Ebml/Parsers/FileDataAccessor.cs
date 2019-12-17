using System;
using System.IO;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;

namespace Otchi.Ebml.Parsers
{
    public class FileDataAccessor: IParserDataAccessor
    {
        private readonly FileStream _fileStream;
        public bool Done => _fileStream.Position >= Length;
        public long Length => _fileStream.Length;

        public async Task<int> ReadAsync(byte[] buffer, int bufferOffset, int count, long offset)
        {
            _fileStream.Seek(offset, SeekOrigin.Begin);
            try
            {
                return await _fileStream.ReadAsync(buffer, bufferOffset, count).ConfigureAwait(false);
            }
            catch (ArgumentException)
            {
                throw new DecodeException();
            }
        }

        public FileDataAccessor(string path)
        {
            _fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
        }
    }
}