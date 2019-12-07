using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackJoinBlocks : MasterElement
	{
		public override VInt Id => MatroskaIds.TrackJoinBlocksId;
		public override string Name => "TrackJoinBlocks";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrackOperation\\TrackJoinBlocks)";
		public override string Description =>
			"Contains the list of all tracks whose Blocks need to be combined to create this virtual track";

		public TrackJoinBlocks(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackJoinBlocksFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackJoinBlocksId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackJoinBlocks(dataSize, position, parent);
		}
	}
}
