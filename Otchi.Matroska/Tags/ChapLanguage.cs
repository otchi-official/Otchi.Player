using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapLanguage : StringElement
	{
		public override VInt Id => MatroskaIds.ChapLanguageId;
		public override string Name => "ChapLanguage";
		public override Path Path => "1*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterDisplay\\ChapLanguage)";
		public override string Description =>
			"The languages corresponding to the string, in the";

		public ChapLanguage(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapLanguageFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapLanguageId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapLanguage(dataSize, position, parent);
		}
	}
}
