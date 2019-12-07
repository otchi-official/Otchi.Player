using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncodings : MasterElement
	{
		public override VInt Id => MatroskaIds.ContentEncodingsId;
		public override string Name => "ContentEncodings";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings)";
		public override string Description =>
			"Settings for several content encoding mechanisms like compression or encryption.";

		public ContentEncodings(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncodingsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncodingsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncodings(dataSize, position, parent);
		}
	}
}
