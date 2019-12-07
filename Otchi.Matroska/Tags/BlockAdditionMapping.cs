using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAdditionMapping : MasterElement
	{
		public override VInt Id => MatroskaIds.BlockAdditionMappingId;
		public override string Name => "BlockAdditionMapping";
		public override Path Path => "0*(\\Segment\\Tracks\\TrackEntry\\BlockAdditionMapping)";
		public override string Description =>
			"Contains elements that describe each value of";

		public BlockAdditionMapping(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAdditionMappingFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAdditionMappingId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAdditionMapping(dataSize, position, parent);
		}
	}
}
