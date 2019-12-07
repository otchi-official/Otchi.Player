using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class WhitePointChromaticityX : DoubleElement
	{
		public override VInt Id => MatroskaIds.WhitePointChromaticityXId;
		public override string Name => "WhitePointChromaticityX";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\WhitePointChromaticityX)";
		public override string Description =>
			"White X chromaticity coordinate as defined by CIE 1931.";

		public WhitePointChromaticityX(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class WhitePointChromaticityXFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.WhitePointChromaticityXId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new WhitePointChromaticityX(dataSize, position, parent);
		}
	}
}
