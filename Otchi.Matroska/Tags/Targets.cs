using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Targets : MasterElement
	{
		public override VInt Id => MatroskaIds.TargetsId;
		public override string Name => "Targets";
		public override Path Path => "1*1(\\Segment\\Tags\\Tag\\Targets)";
		public override string Description =>
			"Specifies which other elements the metadata represented by the Tag applies to. If empty or not present, then the Tag describes everything in the Segment.";

		public Targets(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TargetsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TargetsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Targets(dataSize, position, parent);
		}
	}
}
