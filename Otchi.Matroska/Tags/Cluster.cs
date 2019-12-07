using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Cluster : MasterElement
	{
		public override VInt Id => MatroskaIds.ClusterId;
		public override string Name => "Cluster";
		public override Path Path => "0*(\\Segment\\Cluster)";
		public override string Description =>
			"The Top-Level Element containing the (monolithic) Block structure.";

		public Cluster(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ClusterFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ClusterId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Cluster(dataSize, position, parent);
		}
	}
}
