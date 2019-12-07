using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagBinary : BinaryElement
	{
		public override VInt Id => MatroskaIds.TagBinaryId;
		public override string Name => "TagBinary";
		public override Path Path => "0*1(\\Segment\\Tags\\Tag\\SimpleTag\\TagBinary)";
		public override string Description =>
			"The values of the Tag if it is binary. Note that this cannot be used in the same SimpleTag as TagString.";

		public TagBinary(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagBinaryFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagBinaryId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagBinary(dataSize, position, parent);
		}
	}
}
