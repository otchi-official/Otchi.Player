using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentCompression : MasterElement
	{
		public override VInt Id => MatroskaIds.ContentCompressionId;
		public override string Name => "ContentCompression";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentCompression)";
		public override string Description =>
			"Settings describing the compression used. This Element MUST be present if the value of ContentEncodingType is 0 and absent otherwise. Each block MUST be decompressable even if no previous block is available in order not to prevent seeking.";

		public ContentCompression(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentCompressionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentCompressionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentCompression(dataSize, position, parent);
		}
	}
}
