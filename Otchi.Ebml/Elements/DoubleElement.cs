using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;
using BitConverter = System.BitConverter;

namespace Otchi.Ebml.Elements
{
    public abstract class DoubleElement : EbmlElement
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        protected DoubleElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public double Value { get; protected set; }

        public sealed override EbmlType Type => EbmlType.DoubleType;
        public override async Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                if (Decoded && !forceDecode) return;
                if (parser == null) throw new ArgumentNullException(nameof(parser));
                if (parser.DataAccessor == null)
                    throw new InvalidOperationException(
                        ExceptionsResourceManager.ResourceManager.GetString("InvalidDecodeState",
                            CultureInfo.CurrentCulture));

                switch (DataSize.DataSize)
                {
                    case 0:
                        Value = 0d;
                        break;
                    case 4:
                        var floatBuffer = new byte[4];
                        await parser.DataAccessor.ReadAsync(floatBuffer, 0, 4, DataPosition)
                            .ConfigureAwait(false);
                        Utility.ConvertEndiannes(floatBuffer);
                        Value = BitConverter.ToSingle(floatBuffer);
                        break;
                    case 8:
                        var doubleBuffer = new byte[8];
                        await parser.DataAccessor.ReadAsync(doubleBuffer, 0, 8, DataPosition)
                            .ConfigureAwait(false);
                        Utility.ConvertEndiannes(doubleBuffer);
                        Value = BitConverter.ToDouble(doubleBuffer);
                        break;
                    default:
                        throw new DecodeException(
                            "Can not decode a decimal number that is not either 0, 4 or 8 bytes long");
                }

                Decoded = true;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public override string ToString()
        {
            return $"{Name} - DoubleType: {Value}";
        }
    }
}