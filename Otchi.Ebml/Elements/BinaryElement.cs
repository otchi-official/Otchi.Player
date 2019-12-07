using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Elements
{
    public abstract class BinaryElement : EbmlElement
    {
        protected BinaryElement(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }
        private byte[]? _value;
        public List<byte>? Value => _value?.ToList();


        public sealed override EbmlType Type => EbmlType.Binary;
        public override async Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            if (Decoded && !forceDecode) return;
            if (parser == null) throw new ArgumentNullException(nameof(parser));
            if (parser.DataAccessor == null) throw new InvalidOperationException(
                ExceptionsResourceManager.ResourceManager.GetString("InvalidDecodeState", CultureInfo.CurrentCulture));
            var buffer = new byte[DataSize.DataSize];
            parser.DataAccessor.Position = DataPosition;
            await parser.DataAccessor.ReadAsync(buffer, 0, (int)DataSize.DataSize).ConfigureAwait(false);
            _value = buffer;
            Decoded = true;
        }
    }
}