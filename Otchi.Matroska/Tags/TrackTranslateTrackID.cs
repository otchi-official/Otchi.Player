using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackTranslateTrackID : BinaryElement
	{
		public override VInt Id => MatroskaIds.TrackTranslateTrackIDId;
		public override string Name => "TrackTranslateTrackID";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackTranslate\\TrackTranslateTrackID)";
		public override string Description =>
			"The binary value used to represent this track in the chapter codec data. The format depends on the";

		public TrackTranslateTrackID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackTranslateTrackIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackTranslateTrackIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackTranslateTrackID(dataSize, position, parent);
		}
	}
}
