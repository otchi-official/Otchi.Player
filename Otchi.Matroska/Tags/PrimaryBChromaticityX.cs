using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrimaryBChromaticityX : DoubleElement
	{
		public override VInt Id => MatroskaIds.PrimaryBChromaticityXId;
		public override string Name => "PrimaryBChromaticityX";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\PrimaryBChromaticityX)";
		public override string Description =>
			"Blue X chromaticity coordinate as defined by CIE 1931.";

		public PrimaryBChromaticityX(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimaryBChromaticityXFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimaryBChromaticityXId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrimaryBChromaticityX(dataSize, position, parent);
		}
	}
}
