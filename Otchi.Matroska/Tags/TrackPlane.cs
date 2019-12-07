using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackPlane : MasterElement
	{
		public override VInt Id => MatroskaIds.TrackPlaneId;
		public override string Name => "TrackPlane";
		public override Path Path => "1*(\\Segment\\Tracks\\TrackEntry\\TrackOperation\\TrackCombinePlanes\\TrackPlane)";
		public override string Description =>
			"Contains a video plane track that need to be combined to create this 3D track";

		public TrackPlane(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackPlaneFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackPlaneId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackPlane(dataSize, position, parent);
		}
	}
}
