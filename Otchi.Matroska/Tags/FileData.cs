using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileData : BinaryElement
	{
		public override VInt Id => MatroskaIds.FileDataId;
		public override string Name => "FileData";
		public override Path Path => "1*1(\\Segment\\Attachments\\AttachedFile\\FileData)";
		public override string Description =>
			"The data of the file.";

		public FileData(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileDataFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileDataId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileData(dataSize, position, parent);
		}
	}
}
