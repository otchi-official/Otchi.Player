using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PixelWidth : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PixelWidthId;
		public override string Name => "PixelWidth";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\PixelWidth)";
		public override string Description =>
			"Width of the encoded video frames in pixels.";

		public PixelWidth(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PixelWidthFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PixelWidthId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PixelWidth(dataSize, position, parent);
		}
	}
}
