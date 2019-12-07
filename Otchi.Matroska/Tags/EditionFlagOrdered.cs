using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class EditionFlagOrdered : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.EditionFlagOrderedId;
		public override string Name => "EditionFlagOrdered";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\EditionFlagOrdered)";
		public override string Description =>
			"Specify if the chapters can be defined multiple times and the order to play them is enforced. (1 bit)";

		public EditionFlagOrdered(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class EditionFlagOrderedFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.EditionFlagOrderedId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new EditionFlagOrdered(dataSize, position, parent);
		}
	}
}
