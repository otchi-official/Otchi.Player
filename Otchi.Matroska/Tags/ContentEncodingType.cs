using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncodingType : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentEncodingTypeId;
		public override string Name => "ContentEncodingType";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncodingType)";
		public override string Description =>
			"A value describing what kind of transformation is applied.";

		public ContentEncodingType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncodingTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncodingTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncodingType(dataSize, position, parent);
		}
	}
}
