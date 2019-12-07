using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncAlgo : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ContentEncAlgoId;
		public override string Name => "ContentEncAlgo";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentEncAlgo)";
		public override string Description =>
			"The encryption algorithm used. The value '0' means that the contents have not been encrypted but only signed.";

		public ContentEncAlgo(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncAlgoFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncAlgoId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncAlgo(dataSize, position, parent);
		}
	}
}
