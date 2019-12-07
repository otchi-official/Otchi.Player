using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentCompSettings : BinaryElement
	{
		public override VInt Id => MatroskaIds.ContentCompSettingsId;
		public override string Name => "ContentCompSettings";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentCompression\\ContentCompSettings)";
		public override string Description =>
			"Settings that might be needed by the decompressor. For Header Stripping (`ContentCompAlgo`=3), the bytes that were removed from the beginning of each frames of the track.";

		public ContentCompSettings(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentCompSettingsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentCompSettingsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentCompSettings(dataSize, position, parent);
		}
	}
}
