using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Block : BinaryElement
	{
		public override VInt Id => MatroskaIds.BlockId;
		public override string Name => "Block";
		public override Path Path => "1*1(\\Segment\\Cluster\\BlockGroup\\Block)";
		public override string Description =>
			"Block containing the actual data to be rendered and a timestamp relative to the Cluster Timestamp. (see";

		public Block(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Block(dataSize, position, parent);
		}
	}
}
