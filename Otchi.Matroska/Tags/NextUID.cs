using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class NextUID : BinaryElement
	{
		public override VInt Id => MatroskaIds.NextUIDId;
		public override string Name => "NextUID";
		public override Path Path => "0*1(\\Segment\\Info\\NextUID)";
		public override string Description =>
			"If the Segment is a part of a Linked Segment that uses Hard Linking then either the PrevUID or the NextUID Element is REQUIRED. If a Segment contains a NextUID but not a PrevUID then it MAY be considered as the first Segment of the Linked Segment. The NextUID MUST NOT be equal to the SegmentUID.";

		public NextUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class NextUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.NextUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new NextUID(dataSize, position, parent);
		}
	}
}
