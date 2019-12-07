using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAddIDType : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BlockAddIDTypeId;
		public override string Name => "BlockAddIDType";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\BlockAdditionMapping\\BlockAddIDType)";
		public override string Description =>
			"Stores the registered identifer of the Block Additional Mapping to define how the BlockAdditional data should be handled.";

		public BlockAddIDType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAddIDTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAddIDTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAddIDType(dataSize, position, parent);
		}
	}
}
