using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagLanguageIETF : StringElement
	{
		public override VInt Id => MatroskaIds.TagLanguageIETFId;
		public override string Name => "TagLanguageIETF";
		public override Path Path => "0*1(\\Segment\\Tags\\Tag\\SimpleTag\\TagLanguageIETF)";
		public override string Description =>
			"Specifies the language used in the TagString according to";

		public TagLanguageIETF(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagLanguageIETFFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagLanguageIETFId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagLanguageIETF(dataSize, position, parent);
		}
	}
}
