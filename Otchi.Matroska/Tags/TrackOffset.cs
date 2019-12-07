using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackOffset : IntElement
	{
		public override VInt Id => MatroskaIds.TrackOffsetId;
		public override string Name => "TrackOffset";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrackOffset)";
		public override string Description =>
			"A value to add to the Block's Timestamp. This can be used to adjust the playback offset of a track.";

		public TrackOffset(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackOffsetFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackOffsetId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackOffset(dataSize, position, parent);
		}
	}
}
