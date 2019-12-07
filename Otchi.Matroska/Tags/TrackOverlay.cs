using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackOverlay : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackOverlayId;
		public override string Name => "TrackOverlay";
		public override Path Path => "0*(\\Segment\\Tracks\\TrackEntry\\TrackOverlay)";
		public override string Description =>
			"Specify that this track is an overlay track for the Track specified (in the u-integer). That means when this track has a gap (see";

		public TrackOverlay(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackOverlayFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackOverlayId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackOverlay(dataSize, position, parent);
		}
	}
}
