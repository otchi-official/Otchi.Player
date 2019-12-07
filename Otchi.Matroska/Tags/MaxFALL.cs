using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MaxFALL : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.MaxFALLId;
		public override string Name => "MaxFALL";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MaxFALL)";
		public override string Description =>
			"Maximum brightness of a single full frame (Maximum Frame-Average Light Level) in candelas per square meter (cd/m²).";

		public MaxFALL(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MaxFALLFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MaxFALLId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MaxFALL(dataSize, position, parent);
		}
	}
}
