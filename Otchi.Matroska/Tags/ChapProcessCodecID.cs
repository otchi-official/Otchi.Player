using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapProcessCodecID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapProcessCodecIDId;
		public override string Name => "ChapProcessCodecID";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapProcess\\ChapProcessCodecID)";
		public override string Description =>
			"Contains the type of the codec used for the processing. A value of 0 means native Matroska processing (to be defined), a value of 1 means the";

		public ChapProcessCodecID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapProcessCodecIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapProcessCodecIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapProcessCodecID(dataSize, position, parent);
		}
	}
}
