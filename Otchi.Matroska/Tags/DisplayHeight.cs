using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class DisplayHeight : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.DisplayHeightId;
		public override string Name => "DisplayHeight";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\DisplayHeight)";
		public override string Description =>
			"Height of the video frames to display. Applies to the video frame after cropping (PixelCrop* Elements).";

		public DisplayHeight(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DisplayHeightFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DisplayHeightId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DisplayHeight(dataSize, position, parent);
		}
	}
}
