using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Segment : MasterElement
	{
		public override VInt Id => MatroskaIds.SegmentId;
		public override string Name => "Segment";
		public override Path Path => "1*1(\\Segment)";
		public override string Description =>
			"The Root Element that contains all other Top-Level Elements (Elements defined only at Level 1). A Matroska file is composed of 1 Segment.";

		public Segment(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SegmentFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SegmentId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Segment(dataSize, position, parent);
		}
	}
}
