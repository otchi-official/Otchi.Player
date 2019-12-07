using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class StereoMode : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.StereoModeId;
		public override string Name => "StereoMode";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\StereoMode)";
		public override string Description =>
			"Stereo-3D video mode. There are some more details on";

		public StereoMode(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class StereoModeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.StereoModeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new StereoMode(dataSize, position, parent);
		}
	}
}
