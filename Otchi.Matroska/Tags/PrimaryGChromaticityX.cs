using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrimaryGChromaticityX : DoubleElement
	{
		public override VInt Id => MatroskaIds.PrimaryGChromaticityXId;
		public override string Name => "PrimaryGChromaticityX";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\PrimaryGChromaticityX)";
		public override string Description =>
			"Green X chromaticity coordinate as defined by CIE 1931.";

		public PrimaryGChromaticityX(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimaryGChromaticityXFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimaryGChromaticityXId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrimaryGChromaticityX(dataSize, position, parent);
		}
	}
}
