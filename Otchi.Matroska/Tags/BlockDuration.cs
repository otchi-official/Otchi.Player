using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockDuration : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BlockDurationId;
		public override string Name => "BlockDuration";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\BlockDuration)";
		public override string Description =>
			"The duration of the Block (based on TimestampScale). The BlockDuration Element can be useful at the end of a Track to define the duration of the last frame (as there is no subsequent Block available), or when there is a break in a track like for subtitle tracks.";

		public BlockDuration(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockDurationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockDurationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockDuration(dataSize, position, parent);
		}
	}
}
