using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileMimeType : StringElement
	{
		public override VInt Id => MatroskaIds.FileMimeTypeId;
		public override string Name => "FileMimeType";
		public override Path Path => "1*1(\\Segment\\Attachments\\AttachedFile\\FileMimeType)";
		public override string Description =>
			"MIME type of the file.";

		public FileMimeType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileMimeTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileMimeTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileMimeType(dataSize, position, parent);
		}
	}
}
