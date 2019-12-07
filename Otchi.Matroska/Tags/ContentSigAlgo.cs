using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentSigAlgo : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentSigAlgoId;
		public override string Name => "ContentSigAlgo";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentSigAlgo)";
		public override string Description =>
			"The algorithm used for the signature.";

		public ContentSigAlgo(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentSigAlgoFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentSigAlgoId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentSigAlgo(dataSize, position, parent);
		}
	}
}
