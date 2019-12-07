using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecInfoURL : StringElement
	{
		public override VInt Id => MatroskaIds.CodecInfoURLId;
		public override string Name => "CodecInfoURL";
		public override Path Path => "0*(\\Segment\\Tracks\\TrackEntry\\CodecInfoURL)";
		public override string Description =>
			"A URL to find information about the codec used.";

		public CodecInfoURL(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecInfoURLFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecInfoURLId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecInfoURL(dataSize, position, parent);
		}
	}
}
