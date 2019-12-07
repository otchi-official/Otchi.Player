using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagEditionUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TagEditionUIDId;
		public override string Name => "TagEditionUID";
		public override Path Path => "0*(\\Segment\\Tags\\Tag\\Targets\\TagEditionUID)";
		public override string Description =>
			"A unique ID to identify the EditionEntry(s) the tags belong to. If the value is 0 at this level, the tags apply to all editions in the Segment.";

		public TagEditionUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagEditionUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagEditionUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagEditionUID(dataSize, position, parent);
		}
	}
}
