using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrimaryBChromaticityY : DoubleElement
	{
		public override VInt Id => MatroskaIds.PrimaryBChromaticityYId;
		public override string Name => "PrimaryBChromaticityY";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\PrimaryBChromaticityY)";
		public override string Description =>
			"Blue Y chromaticity coordinate as defined by CIE 1931.";

		public PrimaryBChromaticityY(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimaryBChromaticityYFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimaryBChromaticityYId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrimaryBChromaticityY(dataSize, position, parent);
		}
	}
}
