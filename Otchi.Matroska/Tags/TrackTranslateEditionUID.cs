using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackTranslateEditionUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackTranslateEditionUIDId;
		public override string Name => "TrackTranslateEditionUID";
		public override Path Path => "0*(\\Segment\\Tracks\\TrackEntry\\TrackTranslate\\TrackTranslateEditionUID)";
		public override string Description =>
			"Specify an edition UID on which this translation applies. When not specified, it means for all editions found in the Segment.";

		public TrackTranslateEditionUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackTranslateEditionUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackTranslateEditionUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackTranslateEditionUID(dataSize, position, parent);
		}
	}
}
