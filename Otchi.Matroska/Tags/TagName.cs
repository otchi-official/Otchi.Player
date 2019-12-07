using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagName : StringElement
	{
		public override VInt Id => MatroskaIds.TagNameId;
		public override string Name => "TagName";
		public override Path Path => "1*1(\\Segment\\Tags\\Tag\\SimpleTag\\TagName)";
		public override string Description =>
			"The name of the Tag that is going to be stored.";

		public TagName(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagNameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagNameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagName(dataSize, position, parent);
		}
	}
}
