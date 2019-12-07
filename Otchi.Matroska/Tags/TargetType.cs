using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TargetType : StringElement
	{
		public override VInt Id => MatroskaIds.TargetTypeId;
		public override string Name => "TargetType";
		public override Path Path => "0*1(\\Segment\\Tags\\Tag\\Targets\\TargetType)";
		public override string Description =>
			"An informational string that can be used to display the logical level of the target like \"ALBUM\", \"TRACK\", \"MOVIE\", \"CHAPTER\", etc (see";

		public TargetType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TargetTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TargetTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TargetType(dataSize, position, parent);
		}
	}
}
