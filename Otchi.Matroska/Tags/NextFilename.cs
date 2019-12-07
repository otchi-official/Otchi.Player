using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class NextFilename : StringElement
	{
		public override VInt Id => MatroskaIds.NextFilenameId;
		public override string Name => "NextFilename";
		public override Path Path => "0*1(\\Segment\\Info\\NextFilename)";
		public override string Description =>
			"Provision of the next filename is for display convenience, but NextUID SHOULD be considered authoritative for identifying the Next Segment.";

		public NextFilename(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class NextFilenameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.NextFilenameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new NextFilename(dataSize, position, parent);
		}
	}
}
