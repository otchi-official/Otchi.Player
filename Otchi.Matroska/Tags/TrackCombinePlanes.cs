using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackCombinePlanes : MasterElement
	{
		public override VInt Id => MatroskaIds.TrackCombinePlanesId;
		public override string Name => "TrackCombinePlanes";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrackOperation\\TrackCombinePlanes)";
		public override string Description =>
			"Contains the list of all video plane tracks that need to be combined to create this 3D track";

		public TrackCombinePlanes(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackCombinePlanesFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackCombinePlanesId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackCombinePlanes(dataSize, position, parent);
		}
	}
}
