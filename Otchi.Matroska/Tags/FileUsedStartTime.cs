using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FileUsedStartTime : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FileUsedStartTimeId;
		public override string Name => "FileUsedStartTime";
		public override Path Path => "0*1(\\Segment\\Attachments\\AttachedFile\\FileUsedStartTime)";
		public override string Description =>
			"";

		public FileUsedStartTime(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FileUsedStartTimeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FileUsedStartTimeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FileUsedStartTime(dataSize, position, parent);
		}
	}
}
