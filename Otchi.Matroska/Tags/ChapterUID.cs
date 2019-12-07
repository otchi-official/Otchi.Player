using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterUIDId;
		public override string Name => "ChapterUID";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterUID)";
		public override string Description =>
			"A unique ID to identify the Chapter.";

		public ChapterUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterUID(dataSize, position, parent);
		}
	}
}
