using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MaxCache : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.MaxCacheId;
		public override string Name => "MaxCache";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\MaxCache)";
		public override string Description =>
			"The maximum cache size necessary to store referenced frames in and the current frame. 0 means no cache is needed.";

		public MaxCache(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MaxCacheFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MaxCacheId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MaxCache(dataSize, position, parent);
		}
	}
}
