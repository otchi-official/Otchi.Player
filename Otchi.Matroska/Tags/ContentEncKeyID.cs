using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncKeyID : BinaryElement
	{
		public override VInt Id => MatroskaIds.ContentEncKeyIDId;
		public override string Name => "ContentEncKeyID";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentEncKeyID)";
		public override string Description =>
			"For public key algorithms this is the ID of the public key the the data was encrypted with.";

		public ContentEncKeyID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncKeyIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncKeyIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncKeyID(dataSize, position, parent);
		}
	}
}
