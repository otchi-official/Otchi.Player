using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Title : StringElement
	{
		public override VInt Id => MatroskaIds.TitleId;
		public override string Name => "Title";
		public override Path Path => "0*1(\\Segment\\Info\\Title)";
		public override string Description =>
			"General name of the Segment.";

		public Title(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TitleFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TitleId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Title(dataSize, position, parent);
		}
	}
}
