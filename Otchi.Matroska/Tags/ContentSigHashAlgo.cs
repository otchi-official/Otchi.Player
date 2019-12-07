using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentSigHashAlgo : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentSigHashAlgoId;
		public override string Name => "ContentSigHashAlgo";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentSigHashAlgo)";
		public override string Description =>
			"The hash algorithm used for the signature.";

		public ContentSigHashAlgo(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentSigHashAlgoFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentSigHashAlgoId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentSigHashAlgo(dataSize, position, parent);
		}
	}
}
