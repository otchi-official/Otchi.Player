using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class OldStereoMode : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.OldStereoModeId;
		public override string Name => "OldStereoMode";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\OldStereoMode)";
		public override string Description =>
			"DEPRECATED, DO NOT USE. Bogus StereoMode value used in old versions of libmatroska.";

		public OldStereoMode(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class OldStereoModeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.OldStereoModeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new OldStereoMode(dataSize, position, parent);
		}
	}
}
