using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SliceDuration : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.SliceDurationId;
		public override string Name => "SliceDuration";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\Slices\\TimeSlice\\SliceDuration)";
		public override string Description =>
			"The (scaled) duration to apply to the Element.";

		public SliceDuration(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SliceDurationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SliceDurationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SliceDuration(dataSize, position, parent);
		}
	}
}
