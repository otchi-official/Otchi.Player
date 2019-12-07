using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ReferenceVirtual : IntElement
	{
		public override VInt Id => MatroskaIds.ReferenceVirtualId;
		public override string Name => "ReferenceVirtual";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\ReferenceVirtual)";
		public override string Description =>
			"The Segment Position of the data that would otherwise be in position of the virtual block.";

		public ReferenceVirtual(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ReferenceVirtualFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ReferenceVirtualId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ReferenceVirtual(dataSize, position, parent);
		}
	}
}
