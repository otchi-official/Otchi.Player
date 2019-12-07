using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Channels : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChannelsId;
		public override string Name => "Channels";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Audio\\Channels)";
		public override string Description =>
			"Numbers of channels in the track.";

		public Channels(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChannelsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChannelsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Channels(dataSize, position, parent);
		}
	}
}
