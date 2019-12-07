using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileName : StringElement
	{
		public override VInt Id => MatroskaIds.FileNameId;
		public override string Name => "FileName";
		public override Path Path => "1*1(\\Segment\\Attachments\\AttachedFile\\FileName)";
		public override string Description =>
			"Filename of the attached file.";

		public FileName(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileNameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileNameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileName(dataSize, position, parent);
		}
	}
}
