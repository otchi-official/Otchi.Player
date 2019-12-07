using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Delay : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.DelayId;
		public override string Name => "Delay";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\Slices\\TimeSlice\\Delay)";
		public override string Description =>
			"The (scaled) delay to apply to the Element.";

		public Delay(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DelayFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DelayId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Delay(dataSize, position, parent);
		}
	}
}
