using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Range : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.RangeId;
		public override string Name => "Range";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\Range)";
		public override string Description =>
			"Clipping of the color ranges.";

		public Range(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class RangeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.RangeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Range(dataSize, position, parent);
		}
	}
}
