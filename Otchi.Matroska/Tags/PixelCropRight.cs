using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PixelCropRight : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PixelCropRightId;
		public override string Name => "PixelCropRight";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\PixelCropRight)";
		public override string Description =>
			"The number of video pixels to remove on the right of the image.";

		public PixelCropRight(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PixelCropRightFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PixelCropRightId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PixelCropRight(dataSize, position, parent);
		}
	}
}
