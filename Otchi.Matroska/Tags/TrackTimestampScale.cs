using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackTimestampScale : DoubleElement
	{
		public override VInt Id => MatroskaIds.TrackTimestampScaleId;
		public override string Name => "TrackTimestampScale";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackTimestampScale)";
		public override string Description =>
			"DEPRECATED, DO NOT USE. The scale to apply on this track to work at normal speed in relation with other tracks (mostly used to adjust video speed when the audio length differs).";

		public TrackTimestampScale(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackTimestampScaleFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackTimestampScaleId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackTimestampScale(dataSize, position, parent);
		}
	}
}
