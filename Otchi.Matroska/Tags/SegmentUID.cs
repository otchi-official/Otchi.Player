using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SegmentUID : BinaryElement
	{
		public override VInt Id => MatroskaIds.SegmentUIDId;
		public override string Name => "SegmentUID";
		public override Path Path => "0*1(\\Segment\\Info\\SegmentUID)";
		public override string Description =>
			"If the Segment is a part of a Linked Segment then this Element is REQUIRED.";

		public SegmentUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SegmentUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SegmentUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SegmentUID(dataSize, position, parent);
		}
	}
}
