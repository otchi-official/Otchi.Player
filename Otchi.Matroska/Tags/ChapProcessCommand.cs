using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapProcessCommand : MasterElement
	{
		public override VInt Id => MatroskaIds.ChapProcessCommandId;
		public override string Name => "ChapProcessCommand";
		public override Path Path => "0*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapProcess\\ChapProcessCommand)";
		public override string Description =>
			"Contains all the commands associated to the Atom.";

		public ChapProcessCommand(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapProcessCommandFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapProcessCommandId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapProcessCommand(dataSize, position, parent);
		}
	}
}
