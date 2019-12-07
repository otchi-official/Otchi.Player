using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecID : StringElement
	{
		public override VInt Id => MatroskaIds.CodecIDId;
		public override string Name => "CodecID";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\CodecID)";
		public override string Description =>
			"An ID corresponding to the codec, see the";

		public CodecID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecID(dataSize, position, parent);
		}
	}
}
