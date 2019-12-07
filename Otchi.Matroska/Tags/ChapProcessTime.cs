using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapProcessTime : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapProcessTimeId;
		public override string Name => "ChapProcessTime";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapProcess\\ChapProcessCommand\\ChapProcessTime)";
		public override string Description =>
			"Defines when the process command SHOULD be handled";

		public ChapProcessTime(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapProcessTimeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapProcessTimeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapProcessTime(dataSize, position, parent);
		}
	}
}
