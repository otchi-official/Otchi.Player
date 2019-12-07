using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class AttachedFile : MasterElement
	{
		public override VInt Id => MatroskaIds.AttachedFileId;
		public override string Name => "AttachedFile";
		public override Path Path => "1*(\\Segment\\Attachments\\AttachedFile)";
		public override string Description =>
			"An attached file.";

		public AttachedFile(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AttachedFileFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AttachedFileId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new AttachedFile(dataSize, position, parent);
		}
	}
}
