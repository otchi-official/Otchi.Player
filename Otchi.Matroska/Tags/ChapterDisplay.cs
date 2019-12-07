using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterDisplay : MasterElement
	{
		public override VInt Id => MatroskaIds.ChapterDisplayId;
		public override string Name => "ChapterDisplay";
		public override Path Path => "0*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterDisplay)";
		public override string Description =>
			"Contains all possible strings to use for the chapter display.";

		public ChapterDisplay(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterDisplayFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterDisplayId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterDisplay(dataSize, position, parent);
		}
	}
}
