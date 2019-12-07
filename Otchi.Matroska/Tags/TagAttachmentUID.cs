using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagAttachmentUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TagAttachmentUIDId;
		public override string Name => "TagAttachmentUID";
		public override Path Path => "0*(\\Segment\\Tags\\Tag\\Targets\\TagAttachmentUID)";
		public override string Description =>
			"A unique ID to identify the Attachment(s) the tags belong to. If the value is 0 at this level, the tags apply to all the attachments in the Segment.";

		public TagAttachmentUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagAttachmentUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagAttachmentUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagAttachmentUID(dataSize, position, parent);
		}
	}
}
