using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackPlaneType : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackPlaneTypeId;
		public override string Name => "TrackPlaneType";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackOperation\\TrackCombinePlanes\\TrackPlane\\TrackPlaneType)";
		public override string Description =>
			"The kind of plane this track corresponds to.";

		public TrackPlaneType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackPlaneTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackPlaneTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackPlaneType(dataSize, position, parent);
		}
	}
}
