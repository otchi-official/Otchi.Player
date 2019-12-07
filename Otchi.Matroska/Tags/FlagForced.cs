using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FlagForced : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FlagForcedId;
		public override string Name => "FlagForced";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\FlagForced)";
		public override string Description =>
			"Set if that track MUST be active during playback. There can be many forced track for a kind (audio, video or subs), the player SHOULD select the one which language matches the user preference or the default + forced track. Overlay MAY happen between a forced and non-forced track of the same kind. (1 bit)";

		public FlagForced(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FlagForcedFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FlagForcedId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FlagForced(dataSize, position, parent);
		}
	}
}
