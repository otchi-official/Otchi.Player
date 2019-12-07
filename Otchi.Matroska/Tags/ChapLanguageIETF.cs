using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapLanguageIETF : StringElement
	{
		public override VInt Id => MatroskaIds.ChapLanguageIETFId;
		public override string Name => "ChapLanguageIETF";
		public override Path Path => "0*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterDisplay\\ChapLanguageIETF)";
		public override string Description =>
			"Specifies the language used in the ChapString according to";

		public ChapLanguageIETF(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapLanguageIETFFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapLanguageIETFId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapLanguageIETF(dataSize, position, parent);
		}
	}
}
