using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class EditionFlagDefault : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.EditionFlagDefaultId;
		public override string Name => "EditionFlagDefault";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\EditionFlagDefault)";
		public override string Description =>
			"If a flag is set (1) the edition SHOULD be used as the default one. (1 bit)";

		public EditionFlagDefault(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class EditionFlagDefaultFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.EditionFlagDefaultId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new EditionFlagDefault(dataSize, position, parent);
		}
	}
}
