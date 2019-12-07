using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChannelPositions : BinaryElement
	{
		public override VInt Id => MatroskaIds.ChannelPositionsId;
		public override string Name => "ChannelPositions";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Audio\\ChannelPositions)";
		public override string Description =>
			"Table of horizontal angles for each successive channel, see";

		public ChannelPositions(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChannelPositionsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChannelPositionsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChannelPositions(dataSize, position, parent);
		}
	}
}
