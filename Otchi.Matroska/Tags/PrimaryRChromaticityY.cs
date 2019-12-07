using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrimaryRChromaticityY : DoubleElement
	{
		public override VInt Id => MatroskaIds.PrimaryRChromaticityYId;
		public override string Name => "PrimaryRChromaticityY";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\PrimaryRChromaticityY)";
		public override string Description =>
			"Red Y chromaticity coordinate as defined by CIE 1931.";

		public PrimaryRChromaticityY(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimaryRChromaticityYFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimaryRChromaticityYId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrimaryRChromaticityY(dataSize, position, parent);
		}
	}
}
