using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Elements
{
    public abstract class IntElement: EbmlElement
    {
        protected IntElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public long Value { get; protected set; }

        public sealed override EbmlType Type => EbmlType.SignedInteger;
        public override async Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            if (Decoded && !forceDecode) return;
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            if (parser.DataAccessor == null) throw new InvalidOperationException(
                ExceptionsResourceManager.ResourceManager.GetString("InvalidDecodeState", CultureInfo.CurrentCulture));

            var buffer = new byte[8];
            parser.DataAccessor.Position = DataPosition;
            await parser.DataAccessor.ReadAsync(buffer, 0, (int)DataSize.DataSize).ConfigureAwait(false);
            Value = BitConverter.ToInt64(buffer, 0);

            Decoded = true;
        }

        public override string ToString()
        {
            return $"{Name} - Integer: {Value}";
        }
    }
}