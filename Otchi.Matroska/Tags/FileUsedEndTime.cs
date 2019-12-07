using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileUsedEndTime : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FileUsedEndTimeId;
		public override string Name => "FileUsedEndTime";
		public override Path Path => "0*1(\\Segment\\Attachments\\AttachedFile\\FileUsedEndTime)";
		public override string Description =>
			"";

		public FileUsedEndTime(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileUsedEndTimeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileUsedEndTimeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileUsedEndTime(dataSize, position, parent);
		}
	}
}
