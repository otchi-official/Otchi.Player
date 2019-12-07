using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecDelay : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CodecDelayId;
		public override string Name => "CodecDelay";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\CodecDelay)";
		public override string Description =>
			"CodecDelay is The codec-built-in delay in nanoseconds. This value MUST be subtracted from each block timestamp in order to get the actual timestamp. The value SHOULD be small so the muxing of tracks with the same actual timestamp are in the same Cluster.";

		public CodecDelay(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecDelayFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecDelayId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecDelay(dataSize, position, parent);
		}
	}
}
