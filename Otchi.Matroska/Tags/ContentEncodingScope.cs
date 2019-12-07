using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncodingScope : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentEncodingScopeId;
		public override string Name => "ContentEncodingScope";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncodingScope)";
		public override string Description =>
			"A bit field that describes which Elements have been modified in this way. Values (big endian) can be OR'ed.";

		public ContentEncodingScope(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncodingScopeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncodingScopeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncodingScope(dataSize, position, parent);
		}
	}
}
