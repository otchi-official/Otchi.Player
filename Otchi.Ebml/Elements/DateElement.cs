using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Elements
{
    public abstract class DateElement : EbmlElement
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        protected DateElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public DateTime Value { get; protected set; }

        public sealed override EbmlType Type => EbmlType.Date;
        public override async Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                if (Decoded && !forceDecode) return;
                if (parser == null) throw new ArgumentNullException(nameof(parser));
                if (parser.DataAccessor == null)
                    throw new InvalidOperationException(
                        ExceptionsResourceManager.ResourceManager.GetString(
                            "InvalidDecodeState",
                            CultureInfo.CurrentCulture));


                var buffer = new byte[8];
                await parser.DataAccessor.ReadAsync(
                        buffer,
                        0,
                        (int) DataSize.DataSize,
                        DataPosition)
                    .ConfigureAwait(false);
                Utility.ConvertEndiannes(buffer, (int) DataSize.DataSize);
                Value = EbmlDate.FromNanoSeconds(BitConverter.ToInt64(buffer));

                Decoded = true;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public override string ToString()
        {
            return $"{Name} - Date: {Value}";
        }
    }
}