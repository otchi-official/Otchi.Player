using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TagTrackUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TagTrackUIDId;
		public override string Name => "TagTrackUID";
		public override Path Path => "0*(\\Segment\\Tags\\Tag\\Targets\\TagTrackUID)";
		public override string Description =>
			"A unique ID to identify the Track(s) the tags belong to. If the value is 0 at this level, the tags apply to all tracks in the Segment.";

		public TagTrackUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TagTrackUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TagTrackUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TagTrackUID(dataSize, position, parent);
		}
	}
}
