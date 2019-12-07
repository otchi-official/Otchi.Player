using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ReferenceOffset : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ReferenceOffsetId;
		public override string Name => "ReferenceOffset";
		public override Path Path => "1*1(\\Segment\\Cluster\\BlockGroup\\ReferenceFrame\\ReferenceOffset)";
		public override string Description =>
			"";

		public ReferenceOffset(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ReferenceOffsetFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ReferenceOffsetId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ReferenceOffset(dataSize, position, parent);
		}
	}
}
