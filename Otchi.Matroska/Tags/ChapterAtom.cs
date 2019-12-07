using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterAtom : MasterElement
	{
		public override VInt Id => MatroskaIds.ChapterAtomId;
		public override string Name => "ChapterAtom";
		public override Path Path => "1*(\\Segment\\Chapters\\EditionEntry(1*(\\ChapterAtom)))";
		public override string Description =>
			"Contains the atom information to use as the chapter atom (apply to all tracks).";

		public ChapterAtom(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterAtomFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterAtomId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterAtom(dataSize, position, parent);
		}
	}
}
