using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncryption : MasterElement
	{
		public override VInt Id => MatroskaIds.ContentEncryptionId;
		public override string Name => "ContentEncryption";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption)";
		public override string Description =>
			"Settings describing the encryption used. This Element MUST be present if the value of `ContentEncodingType` is 1 (encryption) and MUST be ignored otherwise.";

		public ContentEncryption(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncryptionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncryptionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncryption(dataSize, position, parent);
		}
	}
}
