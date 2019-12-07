using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MaxCLL : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.MaxCLLId;
		public override string Name => "MaxCLL";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MaxCLL)";
		public override string Description =>
			"Maximum brightness of a single pixel (Maximum Content Light Level) in candelas per square meter (cd/m²).";

		public MaxCLL(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MaxCLLFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MaxCLLId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MaxCLL(dataSize, position, parent);
		}
	}
}
