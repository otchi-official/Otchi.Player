using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterSegmentUID : BinaryElement
	{
		public override VInt Id => MatroskaIds.ChapterSegmentUIDId;
		public override string Name => "ChapterSegmentUID";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterSegmentUID)";
		public override string Description =>
			"The SegmentUID of another Segment to play during this chapter.";

		public ChapterSegmentUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterSegmentUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterSegmentUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterSegmentUID(dataSize, position, parent);
		}
	}
}
