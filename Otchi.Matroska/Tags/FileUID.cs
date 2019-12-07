using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FileUIDId;
		public override string Name => "FileUID";
		public override Path Path => "1*1(\\Segment\\Attachments\\AttachedFile\\FileUID)";
		public override string Description =>
			"Unique ID representing the file, as random as possible.";

		public FileUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileUID(dataSize, position, parent);
		}
	}
}
