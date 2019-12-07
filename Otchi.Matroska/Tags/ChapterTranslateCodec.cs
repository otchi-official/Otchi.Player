using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTranslateCodec : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterTranslateCodecId;
		public override string Name => "ChapterTranslateCodec";
		public override Path Path => "1*1(\\Segment\\Info\\ChapterTranslate\\ChapterTranslateCodec)";
		public override string Description =>
			"The";

		public ChapterTranslateCodec(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTranslateCodecFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTranslateCodecId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTranslateCodec(dataSize, position, parent);
		}
	}
}
