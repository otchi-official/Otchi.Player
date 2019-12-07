using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrevUID : BinaryElement
	{
		public override VInt Id => MatroskaIds.PrevUIDId;
		public override string Name => "PrevUID";
		public override Path Path => "0*1(\\Segment\\Info\\PrevUID)";
		public override string Description =>
			"If the Segment is a part of a Linked Segment that uses Hard Linking then either the PrevUID or the NextUID Element is REQUIRED. If a Segment contains a PrevUID but not a NextUID then it MAY be considered as the last Segment of the Linked Segment. The PrevUID MUST NOT be equal to the SegmentUID.";

		public PrevUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrevUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrevUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrevUID(dataSize, position, parent);
		}
	}
}
