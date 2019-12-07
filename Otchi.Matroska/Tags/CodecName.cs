using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecName : StringElement
	{
		public override VInt Id => MatroskaIds.CodecNameId;
		public override string Name => "CodecName";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\CodecName)";
		public override string Description =>
			"A human-readable string specifying the codec.";

		public CodecName(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecNameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecNameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecName(dataSize, position, parent);
		}
	}
}
