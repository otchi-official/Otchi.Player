using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentCompAlgo : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentCompAlgoId;
		public override string Name => "ContentCompAlgo";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentCompression\\ContentCompAlgo)";
		public override string Description =>
			"The compression algorithm used.";

		public ContentCompAlgo(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentCompAlgoFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentCompAlgoId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentCompAlgo(dataSize, position, parent);
		}
	}
}
