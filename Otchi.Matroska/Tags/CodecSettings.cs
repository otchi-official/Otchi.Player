using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecSettings : StringElement
	{
		public override VInt Id => MatroskaIds.CodecSettingsId;
		public override string Name => "CodecSettings";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\CodecSettings)";
		public override string Description =>
			"A string describing the encoding setting used.";

		public CodecSettings(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecSettingsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecSettingsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecSettings(dataSize, position, parent);
		}
	}
}
