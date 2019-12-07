using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockGroup : MasterElement
	{
		public override VInt Id => MatroskaIds.BlockGroupId;
		public override string Name => "BlockGroup";
		public override Path Path => "0*(\\Segment\\Cluster\\BlockGroup)";
		public override string Description =>
			"Basic container of information containing a single Block and information specific to that Block.";

		public BlockGroup(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockGroupFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockGroupId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockGroup(dataSize, position, parent);
		}
	}
}
