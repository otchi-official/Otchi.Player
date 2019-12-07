using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentSigKeyID : BinaryElement
	{
		public override VInt Id => MatroskaIds.ContentSigKeyIDId;
		public override string Name => "ContentSigKeyID";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentSigKeyID)";
		public override string Description =>
			"This is the ID of the private key the data was signed with.";

		public ContentSigKeyID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentSigKeyIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentSigKeyIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentSigKeyID(dataSize, position, parent);
		}
	}
}
