using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagLanguage : StringElement
	{
		public override VInt Id => MatroskaIds.TagLanguageId;
		public override string Name => "TagLanguage";
		public override Path Path => "1*1(\\Segment\\Tags\\Tag\\SimpleTag\\TagLanguage)";
		public override string Description =>
			"Specifies the language of the tag specified, in the";

		public TagLanguage(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagLanguageFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagLanguageId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagLanguage(dataSize, position, parent);
		}
	}
}
