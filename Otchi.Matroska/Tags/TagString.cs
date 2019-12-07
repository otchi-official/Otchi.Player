using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagString : StringElement
	{
		public override VInt Id => MatroskaIds.TagStringId;
		public override string Name => "TagString";
		public override Path Path => "0*1(\\Segment\\Tags\\Tag\\SimpleTag\\TagString)";
		public override string Description =>
			"The value of the Tag.";

		public TagString(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagStringFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagStringId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagString(dataSize, position, parent);
		}
	}
}
