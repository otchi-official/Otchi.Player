using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class AttachmentLink : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.AttachmentLinkId;
		public override string Name => "AttachmentLink";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\AttachmentLink)";
		public override string Description =>
			"The UID of an attachment that is used by this codec.";

		public AttachmentLink(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AttachmentLinkFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AttachmentLinkId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new AttachmentLink(dataSize, position, parent);
		}
	}
}
