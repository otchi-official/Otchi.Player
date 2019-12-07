using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Attachments : MasterElement
	{
		public override VInt Id => MatroskaIds.AttachmentsId;
		public override string Name => "Attachments";
		public override Path Path => "0*1(\\Segment\\Attachments)";
		public override string Description =>
			"Contain attached files.";

		public Attachments(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AttachmentsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AttachmentsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Attachments(dataSize, position, parent);
		}
	}
}
