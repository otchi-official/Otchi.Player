using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueClusterPosition : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueClusterPositionId;
		public override string Name => "CueClusterPosition";
		public override Path Path => "1*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueClusterPosition)";
		public override string Description =>
			"The Segment Position of the Cluster containing the associated Block.";

		public CueClusterPosition(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueClusterPositionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueClusterPositionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueClusterPosition(dataSize, position, parent);
		}
	}
}
