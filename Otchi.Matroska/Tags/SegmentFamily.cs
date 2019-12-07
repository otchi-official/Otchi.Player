using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SegmentFamily : BinaryElement
	{
		public override VInt Id => MatroskaIds.SegmentFamilyId;
		public override string Name => "SegmentFamily";
		public override Path Path => "0*(\\Segment\\Info\\SegmentFamily)";
		public override string Description =>
			"If the Segment is a part of a Linked Segment that uses Soft Linking then this Element is REQUIRED.";

		public SegmentFamily(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SegmentFamilyFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SegmentFamilyId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SegmentFamily(dataSize, position, parent);
		}
	}
}
