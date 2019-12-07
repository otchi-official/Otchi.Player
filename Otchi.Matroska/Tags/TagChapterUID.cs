using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagChapterUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TagChapterUIDId;
		public override string Name => "TagChapterUID";
		public override Path Path => "0*(\\Segment\\Tags\\Tag\\Targets\\TagChapterUID)";
		public override string Description =>
			"A unique ID to identify the Chapter(s) the tags belong to. If the value is 0 at this level, the tags apply to all chapters in the Segment.";

		public TagChapterUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagChapterUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagChapterUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagChapterUID(dataSize, position, parent);
		}
	}
}
