using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTrack : MasterElement
	{
		public override VInt Id => MatroskaIds.ChapterTrackId;
		public override string Name => "ChapterTrack";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterTrack)";
		public override string Description =>
			"List of tracks on which the chapter applies. If this Element is not present, all tracks apply";

		public ChapterTrack(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTrackFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTrackId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTrack(dataSize, position, parent);
		}
	}
}
