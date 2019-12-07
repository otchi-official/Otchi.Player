using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterPhysicalEquiv : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterPhysicalEquivId;
		public override string Name => "ChapterPhysicalEquiv";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterPhysicalEquiv)";
		public override string Description =>
			"Specify the physical equivalent of this ChapterAtom like \"DVD\" (60) or \"SIDE\" (50), see";

		public ChapterPhysicalEquiv(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterPhysicalEquivFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterPhysicalEquivId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterPhysicalEquiv(dataSize, position, parent);
		}
	}
}
