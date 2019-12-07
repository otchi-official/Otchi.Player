using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterFlagHidden : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterFlagHiddenId;
		public override string Name => "ChapterFlagHidden";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterFlagHidden)";
		public override string Description =>
			"If a chapter is hidden (1), it SHOULD NOT be available to the user interface (but still to Control Tracks; see";

		public ChapterFlagHidden(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterFlagHiddenFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterFlagHiddenId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterFlagHidden(dataSize, position, parent);
		}
	}
}
