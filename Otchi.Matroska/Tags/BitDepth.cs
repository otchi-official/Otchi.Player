using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BitDepth : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BitDepthId;
		public override string Name => "BitDepth";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Audio\\BitDepth)";
		public override string Description =>
			"Bits per sample, mostly used for PCM.";

		public BitDepth(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BitDepthFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BitDepthId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BitDepth(dataSize, position, parent);
		}
	}
}
