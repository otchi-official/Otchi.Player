using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrickTrackUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrickTrackUIDId;
		public override string Name => "TrickTrackUID";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrickTrackUID)";
		public override string Description =>
			"";

		public TrickTrackUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrickTrackUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrickTrackUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrickTrackUID(dataSize, position, parent);
		}
	}
}
