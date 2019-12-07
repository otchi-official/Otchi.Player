using System;
using System.Threading.Tasks;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Parsers;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Seek : MasterElement
	{
		public override VInt Id => MatroskaIds.SeekId;
		public override string Name => "Seek";
		public override Path Path => "1*(\\Segment\\SeekHead\\Seek)";
		public override string Description =>
			"Contains a single seek entry to an EBML Element.";

        public Seek(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

        public ulong? SeekId
        {
            get
            {
                if (!Decoded) throw new InvalidOperationException("Seek element has to be decoded first");
                foreach (var child in this)
                {
                    if (child.Value is SeekID idElement)
                    {
                        return idElement.Value;
                    }
                }

                return null;
            }
        }

        public ulong? SeekPosition
        {
            get
            {
                if (!Decoded) throw new InvalidOperationException("Seek element has to be decoded first");
                foreach (var child in this)
                {
                    if (child.Value is SeekPosition position)
                    {
                        return position.Value;
                    }
                }
                return null;
            }
        }

        public override async Task Decode(EbmlParser parser, bool forceDecode = false)
        {
            await base.Decode(parser, forceDecode).ConfigureAwait(false);
        }
    }

	public class SeekFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SeekId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Seek(dataSize, position, parent);
		}
	}
}
