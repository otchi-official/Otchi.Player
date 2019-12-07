using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapProcess : MasterElement
	{
		public override VInt Id => MatroskaIds.ChapProcessId;
		public override string Name => "ChapProcess";
		public override Path Path => "0*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapProcess)";
		public override string Description =>
			"Contains all the commands associated to the Atom.";

		public ChapProcess(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapProcessFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapProcessId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapProcess(dataSize, position, parent);
		}
	}
}
