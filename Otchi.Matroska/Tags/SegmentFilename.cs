using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SegmentFilename : StringElement
	{
		public override VInt Id => MatroskaIds.SegmentFilenameId;
		public override string Name => "SegmentFilename";
		public override Path Path => "0*1(\\Segment\\Info\\SegmentFilename)";
		public override string Description =>
			"A filename corresponding to this Segment.";

		public SegmentFilename(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SegmentFilenameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SegmentFilenameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SegmentFilename(dataSize, position, parent);
		}
	}
}
