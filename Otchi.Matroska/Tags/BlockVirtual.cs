using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockVirtual : BinaryElement
	{
		public override VInt Id => MatroskaIds.BlockVirtualId;
		public override string Name => "BlockVirtual";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\BlockVirtual)";
		public override string Description =>
			"A Block with no data. It MUST be stored in the stream at the place the real Block would be in display order. (see";

		public BlockVirtual(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockVirtualFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockVirtualId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockVirtual(dataSize, position, parent);
		}
	}
}
