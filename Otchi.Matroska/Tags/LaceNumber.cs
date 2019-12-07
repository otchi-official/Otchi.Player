using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class LaceNumber : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.LaceNumberId;
		public override string Name => "LaceNumber";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\Slices\\TimeSlice\\LaceNumber)";
		public override string Description =>
			"The reverse number of the frame in the lace (0 is the last frame, 1 is the next to last, etc). Being able to interpret this Element is not REQUIRED for playback.";

		public LaceNumber(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class LaceNumberFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.LaceNumberId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new LaceNumber(dataSize, position, parent);
		}
	}
}
