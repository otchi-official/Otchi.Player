using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Chapters : MasterElement
	{
		public override VInt Id => MatroskaIds.ChaptersId;
		public override string Name => "Chapters";
		public override Path Path => "0*1(\\Segment\\Chapters)";
		public override string Description =>
			"A system to define basic menus and partition data. For more detailed information, look at the";

		public Chapters(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChaptersFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChaptersId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Chapters(dataSize, position, parent);
		}
	}
}
