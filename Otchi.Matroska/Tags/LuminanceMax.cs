using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class LuminanceMax : DoubleElement
	{
		public override VInt Id => MatroskaIds.LuminanceMaxId;
		public override string Name => "LuminanceMax";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata\\LuminanceMax)";
		public override string Description =>
			"Maximum luminance. Represented in candelas per square meter (cd/m²).";

		public LuminanceMax(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class LuminanceMaxFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.LuminanceMaxId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new LuminanceMax(dataSize, position, parent);
		}
	}
}
