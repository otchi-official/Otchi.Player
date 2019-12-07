using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrickMasterTrackSegmentUID : BinaryElement
	{
		public override VInt Id => MatroskaIds.TrickMasterTrackSegmentUIDId;
		public override string Name => "TrickMasterTrackSegmentUID";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrickMasterTrackSegmentUID)";
		public override string Description =>
			"";

		public TrickMasterTrackSegmentUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrickMasterTrackSegmentUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrickMasterTrackSegmentUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrickMasterTrackSegmentUID(dataSize, position, parent);
		}
	}
}
