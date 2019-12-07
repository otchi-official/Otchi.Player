using System;

namespace Otchi.Ebml
{
    public static class Utility
    {
        /// <summary>
        /// Most of the data in the Ebml Documents are encoded as Big Endian.
        /// We therefore convert the Endiannes to match the one of the host CPU.
        /// </summary>
        /// <param name="buffer">The buffer to be converted</param>
        /// <param name="filledSize">An optimization parameter indicating up until what point the buffer contains data.
        /// So if we have a buffer of say 200 bytes, but only a few are used you have to indicate the position of the last used byte.
        /// </param>
        /// <returns>
        /// The converted array of bytes in the endiannes of the CPU.
        /// </returns>
        public static byte[] ConvertEndiannes(byte[] buffer, int filledSize = -1)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            if (filledSize < 0)
                filledSize = buffer.Length;

            if (!BitConverter.IsLittleEndian) return buffer;
            for (var i = 0; i < filledSize / 2; i++)
            {
                var temp = buffer[i];
                buffer[i] = buffer[filledSize - i - 1];
                buffer[filledSize - i - 1] = temp;
            }

            return buffer;
        }
    }
}