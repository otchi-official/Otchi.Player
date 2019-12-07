using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BitsPerChannel : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BitsPerChannelId;
		public override string Name => "BitsPerChannel";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\BitsPerChannel)";
		public override string Description =>
			"Number of decoded bits per channel. A value of 0 indicates that the BitsPerChannel is unspecified.";

		public BitsPerChannel(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BitsPerChannelFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BitsPerChannelId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BitsPerChannel(dataSize, position, parent);
		}
	}
}
