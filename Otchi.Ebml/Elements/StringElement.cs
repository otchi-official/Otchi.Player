using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Elements
{
    public abstract class StringElement : EbmlElement
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);


        protected StringElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public string Value { get; protected set; } = string.Empty;

        public sealed override EbmlType Type => EbmlType.String;

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

                var bytes = new byte[DataSize.DataSize];
                await parser.DataAccessor.ReadAsync(bytes, 0, (int) DataSize.DataSize, DataPosition)
                    .ConfigureAwait(false);
                Value = Encoding.Default.GetString(bytes);

                Decoded = true;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public override string ToString()
        {
            return $"{Name} - String: {Value}";
        }
    }
}