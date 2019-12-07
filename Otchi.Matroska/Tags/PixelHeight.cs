using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PixelHeight : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PixelHeightId;
		public override string Name => "PixelHeight";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\PixelHeight)";
		public override string Description =>
			"Height of the encoded video frames in pixels.";

		public PixelHeight(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PixelHeightFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PixelHeightId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PixelHeight(dataSize, position, parent);
		}
	}
}
