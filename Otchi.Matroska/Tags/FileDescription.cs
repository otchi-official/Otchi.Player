using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileDescription : StringElement
	{
		public override VInt Id => MatroskaIds.FileDescriptionId;
		public override string Name => "FileDescription";
		public override Path Path => "0*1(\\Segment\\Attachments\\AttachedFile\\FileDescription)";
		public override string Description =>
			"A human-friendly name for the attached file.";

		public FileDescription(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileDescriptionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileDescriptionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileDescription(dataSize, position, parent);
		}
	}
}
