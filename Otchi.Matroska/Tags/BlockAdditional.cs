using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAdditional : BinaryElement
	{
		public override VInt Id => MatroskaIds.BlockAdditionalId;
		public override string Name => "BlockAdditional";
		public override Path Path => "1*1(\\Segment\\Cluster\\BlockGroup\\BlockAdditions\\BlockMore\\BlockAdditional)";
		public override string Description =>
			"Interpreted by the codec as it wishes (using the BlockAddID).";

		public BlockAdditional(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAdditionalFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAdditionalId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAdditional(dataSize, position, parent);
		}
	}
}
