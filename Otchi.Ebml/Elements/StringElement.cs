using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Elements
{
    public abstract class StringElement : EbmlElement
    {

        protected StringElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public string Value { get; protected set; } = string.Empty;

        public sealed override EbmlType Type => EbmlType.StringType;

        public override async Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            if (Decoded && !forceDecode) return;
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            if (parser.DataAccessor == null) throw new InvalidOperationException(
                ExceptionsResourceManager.ResourceManager.GetString("InvalidDecodeState", CultureInfo.CurrentCulture));

            var bytes = new byte[DataSize.DataSize];
            parser.DataAccessor.Position = DataPosition;
            await parser.DataAccessor.ReadAsync(bytes, 0, (int)DataSize.DataSize).ConfigureAwait(false);
            Value = Encoding.Default.GetString(bytes);

            Decoded = true;
        }

        public override string ToString()
        {
            return $"{Name} - StringType: {Value}";
        }
    }
}