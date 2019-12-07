using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapProcessPrivate : BinaryElement
	{
		public override VInt Id => MatroskaIds.ChapProcessPrivateId;
		public override string Name => "ChapProcessPrivate";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapProcess\\ChapProcessPrivate)";
		public override string Description =>
			"Some optional data attached to the ChapProcessCodecID information.";

		public ChapProcessPrivate(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapProcessPrivateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapProcessPrivateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapProcessPrivate(dataSize, position, parent);
		}
	}
}
