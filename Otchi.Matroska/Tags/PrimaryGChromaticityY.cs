using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrimaryGChromaticityY : DoubleElement
	{
		public override VInt Id => MatroskaIds.PrimaryGChromaticityYId;
		public override string Name => "PrimaryGChromaticityY";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\PrimaryGChromaticityY)";
		public override string Description =>
			"Green Y chromaticity coordinate as defined by CIE 1931.";

		public PrimaryGChromaticityY(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimaryGChromaticityYFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimaryGChromaticityYId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrimaryGChromaticityY(dataSize, position, parent);
		}
	}
}
