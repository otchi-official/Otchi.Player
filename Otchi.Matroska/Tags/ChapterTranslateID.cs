using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTranslateID : BinaryElement
	{
		public override VInt Id => MatroskaIds.ChapterTranslateIDId;
		public override string Name => "ChapterTranslateID";
		public override Path Path => "1*1(\\Segment\\Info\\ChapterTranslate\\ChapterTranslateID)";
		public override string Description =>
			"The binary value used to represent this Segment in the chapter codec data. The format depends on the";

		public ChapterTranslateID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTranslateIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTranslateIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTranslateID(dataSize, position, parent);
		}
	}
}
