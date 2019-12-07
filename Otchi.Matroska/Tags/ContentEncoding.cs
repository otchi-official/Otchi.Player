using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncoding : MasterElement
	{
		public override VInt Id => MatroskaIds.ContentEncodingId;
		public override string Name => "ContentEncoding";
		public override Path Path => "1*(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding)";
		public override string Description =>
			"Settings for one content encoding like compression or encryption.";

		public ContentEncoding(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncodingFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncodingId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncoding(dataSize, position, parent);
		}
	}
}
