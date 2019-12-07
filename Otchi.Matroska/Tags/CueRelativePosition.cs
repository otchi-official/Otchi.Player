using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueRelativePosition : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueRelativePositionId;
		public override string Name => "CueRelativePosition";
		public override Path Path => "0*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueRelativePosition)";
		public override string Description =>
			"The relative position inside the Cluster of the referenced SimpleBlock or BlockGroup with 0 being the first possible position for an Element inside that Cluster.";

		public CueRelativePosition(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueRelativePositionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueRelativePositionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueRelativePosition(dataSize, position, parent);
		}
	}
}
