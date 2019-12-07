using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class WhitePointChromaticityY : DoubleElement
	{
		public override VInt Id => MatroskaIds.WhitePointChromaticityYId;
		public override string Name => "WhitePointChromaticityY";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\WhitePointChromaticityY)";
		public override string Description =>
			"White Y chromaticity coordinate as defined by CIE 1931.";

		public WhitePointChromaticityY(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class WhitePointChromaticityYFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.WhitePointChromaticityYId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new WhitePointChromaticityY(dataSize, position, parent);
		}
	}
}
