using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueRefCluster : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueRefClusterId;
		public override string Name => "CueRefCluster";
		public override Path Path => "1*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueReference\\CueRefCluster)";
		public override string Description =>
			"The Segment Position of the Cluster containing the referenced Block.";

		public CueRefCluster(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueRefClusterFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueRefClusterId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueRefCluster(dataSize, position, parent);
		}
	}
}
