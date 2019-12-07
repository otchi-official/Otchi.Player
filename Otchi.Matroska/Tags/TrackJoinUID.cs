using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackJoinUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackJoinUIDId;
		public override string Name => "TrackJoinUID";
		public override Path Path => "1*(\\Segment\\Tracks\\TrackEntry\\TrackOperation\\TrackJoinBlocks\\TrackJoinUID)";
		public override string Description =>
			"The trackUID number of a track whose blocks are used to create this virtual track.";

		public TrackJoinUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackJoinUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackJoinUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackJoinUID(dataSize, position, parent);
		}
	}
}
