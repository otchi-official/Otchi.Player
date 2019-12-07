using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTranslate : MasterElement
	{
		public override VInt Id => MatroskaIds.ChapterTranslateId;
		public override string Name => "ChapterTranslate";
		public override Path Path => "0*(\\Segment\\Info\\ChapterTranslate)";
		public override string Description =>
			"A tuple of corresponding ID used by chapter codecs to represent this Segment.";

		public ChapterTranslate(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTranslateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTranslateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTranslate(dataSize, position, parent);
		}
	}
}
