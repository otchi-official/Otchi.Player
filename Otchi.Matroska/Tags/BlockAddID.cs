using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAddID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BlockAddIDId;
		public override string Name => "BlockAddID";
		public override Path Path => "1*1(\\Segment\\Cluster\\BlockGroup\\BlockAdditions\\BlockMore\\BlockAddID)";
		public override string Description =>
			"An ID to identify the BlockAdditional level. A value of 1 means the BlockAdditional data is interpreted as additional data passed to the codec with the Block data.";

		public BlockAddID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAddIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAddIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAddID(dataSize, position, parent);
		}
	}
}
