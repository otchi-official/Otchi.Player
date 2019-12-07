using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ColourSpace : BinaryElement
	{
		public override VInt Id => MatroskaIds.ColourSpaceId;
		public override string Name => "ColourSpace";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\ColourSpace)";
		public override string Description =>
			"Specify the pixel format used for the Track's data as a FourCC. This value is similar in scope to the biCompression value of AVI's BITMAPINFOHEADER.";

		public ColourSpace(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ColourSpaceFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ColourSpaceId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ColourSpace(dataSize, position, parent);
		}
	}
}
