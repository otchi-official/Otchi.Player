using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrickTrackSegmentUID : BinaryElement
	{
		public override VInt Id => MatroskaIds.TrickTrackSegmentUIDId;
		public override string Name => "TrickTrackSegmentUID";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrickTrackSegmentUID)";
		public override string Description =>
			"";

		public TrickTrackSegmentUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrickTrackSegmentUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrickTrackSegmentUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrickTrackSegmentUID(dataSize, position, parent);
		}
	}
}
