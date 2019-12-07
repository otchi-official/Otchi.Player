using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncodingOrder : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentEncodingOrderId;
		public override string Name => "ContentEncodingOrder";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncodingOrder)";
		public override string Description =>
			"Tells when this modification was used during encoding/muxing starting with 0 and counting upwards. The decoder/demuxer has to start with the highest order number it finds and work its way down. This value has to be unique over all ContentEncodingOrder Elements in the TrackEntry that contains this ContentEncodingOrder element.";

		public ContentEncodingOrder(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncodingOrderFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncodingOrderId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncodingOrder(dataSize, position, parent);
		}
	}
}
