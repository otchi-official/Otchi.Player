using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapProcessData : BinaryElement
	{
		public override VInt Id => MatroskaIds.ChapProcessDataId;
		public override string Name => "ChapProcessData";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapProcess\\ChapProcessCommand\\ChapProcessData)";
		public override string Description =>
			"Contains the command information. The data SHOULD be interpreted depending on the ChapProcessCodecID value.";

		public ChapProcessData(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapProcessDataFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapProcessDataId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapProcessData(dataSize, position, parent);
		}
	}
}
