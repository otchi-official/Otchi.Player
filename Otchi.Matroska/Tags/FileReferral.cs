using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileReferral : BinaryElement
	{
		public override VInt Id => MatroskaIds.FileReferralId;
		public override string Name => "FileReferral";
		public override Path Path => "0*1(\\Segment\\Attachments\\AttachedFile\\FileReferral)";
		public override string Description =>
			"A binary value that a track/codec can refer to when the attachment is needed.";

		public FileReferral(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileReferralFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileReferralId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileReferral(dataSize, position, parent);
		}
	}
}
