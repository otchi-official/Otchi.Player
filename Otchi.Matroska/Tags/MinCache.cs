using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MinCache : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.MinCacheId;
		public override string Name => "MinCache";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\MinCache)";
		public override string Description =>
			"The minimum number of frames a player SHOULD be able to cache during playback. If set to 0, the reference pseudo-cache system is not used.";

		public MinCache(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MinCacheFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MinCacheId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MinCache(dataSize, position, parent);
		}
	}
}
