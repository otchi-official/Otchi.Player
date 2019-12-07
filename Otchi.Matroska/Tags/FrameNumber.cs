using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FrameNumber : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FrameNumberId;
		public override string Name => "FrameNumber";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\Slices\\TimeSlice\\FrameNumber)";
		public override string Description =>
			"The number of the frame to generate from this lace with this delay (allow you to generate many frames from the same Block/Frame).";

		public FrameNumber(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FrameNumberFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FrameNumberId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FrameNumber(dataSize, position, parent);
		}
	}
}
