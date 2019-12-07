using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagDefault : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TagDefaultId;
		public override string Name => "TagDefault";
		public override Path Path => "1*1(\\Segment\\Tags\\Tag\\SimpleTag\\TagDefault)";
		public override string Description =>
			"A boolean value to indicate if this is the default/original language to use for the given tag.";

		public TagDefault(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagDefaultFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagDefaultId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagDefault(dataSize, position, parent);
		}
	}
}
