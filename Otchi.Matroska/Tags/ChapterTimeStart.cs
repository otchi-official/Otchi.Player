using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTimeStart : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterTimeStartId;
		public override string Name => "ChapterTimeStart";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterTimeStart)";
		public override string Description =>
			"Timestamp of the start of Chapter (not scaled).";

		public ChapterTimeStart(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTimeStartFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTimeStartId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTimeStart(dataSize, position, parent);
		}
	}
}
