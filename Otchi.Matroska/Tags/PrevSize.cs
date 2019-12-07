using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrevSize : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PrevSizeId;
		public override string Name => "PrevSize";
		public override Path Path => "0*1(\\Segment\\Cluster\\PrevSize)";
		public override string Description =>
			"Size of the previous Cluster, in octets. Can be useful for backward playing.";

		public PrevSize(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrevSizeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrevSizeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrevSize(dataSize, position, parent);
		}
	}
}
