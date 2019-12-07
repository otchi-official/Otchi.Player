using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterStringUID : StringElement
	{
		public override VInt Id => MatroskaIds.ChapterStringUIDId;
		public override string Name => "ChapterStringUID";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterStringUID)";
		public override string Description =>
			"A unique string ID to identify the Chapter. Use for";

		public ChapterStringUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterStringUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterStringUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterStringUID(dataSize, position, parent);
		}
	}
}
