using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecDecodeAll : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CodecDecodeAllId;
		public override string Name => "CodecDecodeAll";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\CodecDecodeAll)";
		public override string Description =>
			"The codec can decode potentially damaged data (1 bit).";

		public CodecDecodeAll(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecDecodeAllFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecDecodeAllId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecDecodeAll(dataSize, position, parent);
		}
	}
}
