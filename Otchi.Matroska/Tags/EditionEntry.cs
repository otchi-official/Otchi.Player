using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class EditionEntry : MasterElement
	{
		public override VInt Id => MatroskaIds.EditionEntryId;
		public override string Name => "EditionEntry";
		public override Path Path => "1*(\\Segment\\Chapters\\EditionEntry)";
		public override string Description =>
			"Contains all information about a Segment edition.";

		public EditionEntry(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class EditionEntryFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.EditionEntryId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new EditionEntry(dataSize, position, parent);
		}
	}
}
