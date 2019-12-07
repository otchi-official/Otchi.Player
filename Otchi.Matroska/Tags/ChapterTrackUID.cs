using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTrackUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterTrackUIDId;
		public override string Name => "ChapterTrackUID";
		public override Path Path => "1*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterTrack\\ChapterTrackUID)";
		public override string Description =>
			"UID of the Track to apply this chapter too. In the absence of a control track, choosing this chapter will select the listed Tracks and deselect unlisted tracks. Absence of this Element indicates that the Chapter SHOULD be applied to any currently used Tracks.";

		public ChapterTrackUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTrackUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTrackUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTrackUID(dataSize, position, parent);
		}
	}
}
