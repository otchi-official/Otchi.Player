using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PixelCropTop : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PixelCropTopId;
		public override string Name => "PixelCropTop";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\PixelCropTop)";
		public override string Description =>
			"The number of video pixels to remove at the top of the image.";

		public PixelCropTop(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PixelCropTopFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PixelCropTopId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PixelCropTop(dataSize, position, parent);
		}
	}
}
