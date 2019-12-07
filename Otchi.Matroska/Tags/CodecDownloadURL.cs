using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecDownloadURL : StringElement
	{
		public override VInt Id => MatroskaIds.CodecDownloadURLId;
		public override string Name => "CodecDownloadURL";
		public override Path Path => "0*(\\Segment\\Tracks\\TrackEntry\\CodecDownloadURL)";
		public override string Description =>
			"A URL to download about the codec used.";

		public CodecDownloadURL(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecDownloadURLFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecDownloadURLId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecDownloadURL(dataSize, position, parent);
		}
	}
}
