using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PixelCropLeft : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PixelCropLeftId;
		public override string Name => "PixelCropLeft";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\PixelCropLeft)";
		public override string Description =>
			"The number of video pixels to remove on the left of the image.";

		public PixelCropLeft(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PixelCropLeftFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PixelCropLeftId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PixelCropLeft(dataSize, position, parent);
		}
	}
}
