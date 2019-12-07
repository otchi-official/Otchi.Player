using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class EditionUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.EditionUIDId;
		public override string Name => "EditionUID";
		public override Path Path => "0*1(\\Segment\\Chapters\\EditionEntry\\EditionUID)";
		public override string Description =>
			"A unique ID to identify the edition. It's useful for tagging an edition.";

		public EditionUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class EditionUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.EditionUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new EditionUID(dataSize, position, parent);
		}
	}
}
