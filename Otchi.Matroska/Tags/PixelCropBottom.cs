using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PixelCropBottom : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PixelCropBottomId;
		public override string Name => "PixelCropBottom";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\PixelCropBottom)";
		public override string Description =>
			"The number of video pixels to remove at the bottom of the image.";

		public PixelCropBottom(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PixelCropBottomFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PixelCropBottomId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PixelCropBottom(dataSize, position, parent);
		}
	}
}
