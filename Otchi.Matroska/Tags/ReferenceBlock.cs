using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ReferenceBlock : IntElement
	{
		public override VInt Id => MatroskaIds.ReferenceBlockId;
		public override string Name => "ReferenceBlock";
		public override Path Path => "0*(\\Segment\\Cluster\\BlockGroup\\ReferenceBlock)";
		public override string Description =>
			"Timestamp of another frame used as a reference (ie: B or P frame). The timestamp is relative to the block it's attached to.";

		public ReferenceBlock(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ReferenceBlockFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ReferenceBlockId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ReferenceBlock(dataSize, position, parent);
		}
	}
}
