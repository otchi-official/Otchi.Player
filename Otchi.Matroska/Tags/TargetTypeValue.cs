using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TargetTypeValue : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TargetTypeValueId;
		public override string Name => "TargetTypeValue";
		public override Path Path => "0*1(\\Segment\\Tags\\Tag\\Targets\\TargetTypeValue)";
		public override string Description =>
			"The lowest hierarchy found in music or movies.";

		public TargetTypeValue(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TargetTypeValueFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TargetTypeValueId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TargetTypeValue(dataSize, position, parent);
		}
	}
}
