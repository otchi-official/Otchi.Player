using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrimaryRChromaticityX : DoubleElement
	{
		public override VInt Id => MatroskaIds.PrimaryRChromaticityXId;
		public override string Name => "PrimaryRChromaticityX";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\PrimaryRChromaticityX)";
		public override string Description =>
			"Red X chromaticity coordinate as defined by CIE 1931.";

		public PrimaryRChromaticityX(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimaryRChromaticityXFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimaryRChromaticityXId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrimaryRChromaticityX(dataSize, position, parent);
		}
	}
}
