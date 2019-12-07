using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAdditionID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BlockAdditionIDId;
		public override string Name => "BlockAdditionID";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\Slices\\TimeSlice\\BlockAdditionID)";
		public override string Description =>
			"The ID of the BlockAdditional Element (0 is the main Block).";

		public BlockAdditionID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAdditionIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAdditionIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAdditionID(dataSize, position, parent);
		}
	}
}
