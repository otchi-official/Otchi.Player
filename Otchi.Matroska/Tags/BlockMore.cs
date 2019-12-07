using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockMore : MasterElement
	{
		public override VInt Id => MatroskaIds.BlockMoreId;
		public override string Name => "BlockMore";
		public override Path Path => "1*(\\Segment\\Cluster\\BlockGroup\\BlockAdditions\\BlockMore)";
		public override string Description =>
			"Contain the BlockAdditional and some parameters.";

		public BlockMore(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockMoreFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockMoreId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockMore(dataSize, position, parent);
		}
	}
}
