using System.IO;
using System.Threading.Tasks;

namespace Otchi.Ebml.Parsers
{
    public interface IParserDataAccessor
    {
        bool Done { get; }
        long Length { get; }
        Task<int> ReadAsync(byte[] buffer, int bufferOffset, int count, long offset);
    }
}