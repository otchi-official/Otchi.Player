using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Tags : MasterElement
	{
		public override VInt Id => MatroskaIds.TagsId;
		public override string Name => "Tags";
		public override Path Path => "0*(\\Segment\\Tags)";
		public override string Description =>
			"Element containing metadata describing Tracks, Editions, Chapters, Attachments, or the Segment as a whole. A list of valid tags can be found";

		public Tags(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Tags(dataSize, position, parent);
		}
	}
}
