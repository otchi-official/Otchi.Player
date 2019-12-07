using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FlagDefault : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FlagDefaultId;
		public override string Name => "FlagDefault";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\FlagDefault)";
		public override string Description =>
			"Set if that track (audio, video or subs) SHOULD be active if no language found matches the user preference. (1 bit)";

		public FlagDefault(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FlagDefaultFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FlagDefaultId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FlagDefault(dataSize, position, parent);
		}
	}
}
