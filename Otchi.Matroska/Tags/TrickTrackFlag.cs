using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrickTrackFlag : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrickTrackFlagId;
		public override string Name => "TrickTrackFlag";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrickTrackFlag)";
		public override string Description =>
			"";

		public TrickTrackFlag(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrickTrackFlagFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrickTrackFlagId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrickTrackFlag(dataSize, position, parent);
		}
	}
}
