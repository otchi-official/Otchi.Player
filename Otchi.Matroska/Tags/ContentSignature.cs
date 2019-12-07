using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentSignature : BinaryElement
	{
		public override VInt Id => MatroskaIds.ContentSignatureId;
		public override string Name => "ContentSignature";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentSignature)";
		public override string Description =>
			"A cryptographic signature of the contents.";

		public ContentSignature(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentSignatureFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentSignatureId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentSignature(dataSize, position, parent);
		}
	}
}
