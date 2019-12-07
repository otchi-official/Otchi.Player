using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrickMasterTrackUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrickMasterTrackUIDId;
		public override string Name => "TrickMasterTrackUID";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrickMasterTrackUID)";
		public override string Description =>
			"";

		public TrickMasterTrackUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrickMasterTrackUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrickMasterTrackUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrickMasterTrackUID(dataSize, position, parent);
		}
	}
}
