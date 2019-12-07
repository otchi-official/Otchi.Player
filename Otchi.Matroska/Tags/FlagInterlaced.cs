using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FlagInterlaced : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FlagInterlacedId;
		public override string Name => "FlagInterlaced";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\FlagInterlaced)";
		public override string Description =>
			"A flag to declare if the video is known to be progressive or interlaced and if applicable to declare details about the interlacement.";

		public FlagInterlaced(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FlagInterlacedFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FlagInterlacedId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FlagInterlaced(dataSize, position, parent);
		}
	}
}
