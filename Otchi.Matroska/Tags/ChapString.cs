using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapString : StringElement
	{
		public override VInt Id => MatroskaIds.ChapStringId;
		public override string Name => "ChapString";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterDisplay\\ChapString)";
		public override string Description =>
			"Contains the string to use as the chapter atom.";

		public ChapString(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapStringFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapStringId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapString(dataSize, position, parent);
		}
	}
}
