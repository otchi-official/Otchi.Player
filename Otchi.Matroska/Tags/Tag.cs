using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Tag : MasterElement
	{
		public override VInt Id => MatroskaIds.TagId;
		public override string Name => "Tag";
		public override Path Path => "1*(\\Segment\\Tags\\Tag)";
		public override string Description =>
			"A single metadata descriptor.";

		public Tag(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Tag(dataSize, position, parent);
		}
	}
}
