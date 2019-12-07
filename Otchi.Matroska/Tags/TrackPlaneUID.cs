using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackPlaneUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackPlaneUIDId;
		public override string Name => "TrackPlaneUID";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackOperation\\TrackCombinePlanes\\TrackPlane\\TrackPlaneUID)";
		public override string Description =>
			"The trackUID number of the track representing the plane.";

		public TrackPlaneUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackPlaneUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackPlaneUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackPlaneUID(dataSize, position, parent);
		}
	}
}
