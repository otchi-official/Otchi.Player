using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FlagLacing : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FlagLacingId;
		public override string Name => "FlagLacing";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\FlagLacing)";
		public override string Description =>
			"Set if the track MAY contain blocks using lacing. (1 bit)";

		public FlagLacing(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FlagLacingFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FlagLacingId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FlagLacing(dataSize, position, parent);
		}
	}
}
