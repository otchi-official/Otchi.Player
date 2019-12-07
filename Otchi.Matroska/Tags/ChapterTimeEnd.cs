using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTimeEnd : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterTimeEndId;
		public override string Name => "ChapterTimeEnd";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterTimeEnd)";
		public override string Description =>
			"Timestamp of the end of Chapter (timestamp excluded, not scaled).";

		public ChapterTimeEnd(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTimeEndFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTimeEndId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTimeEnd(dataSize, position, parent);
		}
	}
}
