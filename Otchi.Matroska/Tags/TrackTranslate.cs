using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackTranslate : MasterElement
	{
		public override VInt Id => MatroskaIds.TrackTranslateId;
		public override string Name => "TrackTranslate";
		public override Path Path => "0*(\\Segment\\Tracks\\TrackEntry\\TrackTranslate)";
		public override string Description =>
			"The track identification for the given Chapter Codec.";

		public TrackTranslate(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackTranslateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackTranslateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackTranslate(dataSize, position, parent);
		}
	}
}
