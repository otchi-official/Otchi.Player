using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAdditions : MasterElement
	{
		public override VInt Id => MatroskaIds.BlockAdditionsId;
		public override string Name => "BlockAdditions";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\BlockAdditions)";
		public override string Description =>
			"Contain additional blocks to complete the main one. An EBML parser that has no knowledge of the Block structure could still see and use/skip these data.";

		public BlockAdditions(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAdditionsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAdditionsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAdditions(dataSize, position, parent);
		}
	}
}
