using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class LuminanceMin : DoubleElement
	{
		public override VInt Id => MatroskaIds.LuminanceMinId;
		public override string Name => "LuminanceMin";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\LuminanceMin)";
		public override string Description =>
			"Minimum luminance. Represented in candelas per square meter (cd/m²).";

		public LuminanceMin(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class LuminanceMinFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.LuminanceMinId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new LuminanceMin(dataSize, position, parent);
		}
	}
}
