using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterSegmentEditionUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterSegmentEditionUIDId;
		public override string Name => "ChapterSegmentEditionUID";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterSegmentEditionUID)";
		public override string Description =>
			"The EditionUID to play from the Segment linked in ChapterSegmentUID. If ChapterSegmentEditionUID is undeclared then no Edition of the linked Segment is used.";

		public ChapterSegmentEditionUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterSegmentEditionUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterSegmentEditionUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterSegmentEditionUID(dataSize, position, parent);
		}
	}
}
