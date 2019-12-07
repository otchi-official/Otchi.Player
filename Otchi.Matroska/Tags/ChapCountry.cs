using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapCountry : StringElement
	{
		public override VInt Id => MatroskaIds.ChapCountryId;
		public override string Name => "ChapCountry";
		public override Path Path => "0*(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterDisplay\\ChapCountry)";
		public override string Description =>
			"The countries corresponding to the string, same 2 octets as in";

		public ChapCountry(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapCountryFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapCountryId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapCountry(dataSize, position, parent);
		}
	}
}
