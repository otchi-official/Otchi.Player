using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class DisplayWidth : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.DisplayWidthId;
		public override string Name => "DisplayWidth";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\DisplayWidth)";
		public override string Description =>
			"Width of the video frames to display. Applies to the video frame after cropping (PixelCrop* Elements).";

		public DisplayWidth(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DisplayWidthFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DisplayWidthId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DisplayWidth(dataSize, position, parent);
		}
	}
}
