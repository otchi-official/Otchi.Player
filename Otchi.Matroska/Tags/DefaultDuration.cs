using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class DefaultDuration : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.DefaultDurationId;
		public override string Name => "DefaultDuration";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\DefaultDuration)";
		public override string Description =>
			"Number of nanoseconds (not scaled via TimestampScale) per frame ('frame' in the Matroska sense -- one Element put into a (Simple)Block).";

		public DefaultDuration(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DefaultDurationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DefaultDurationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DefaultDuration(dataSize, position, parent);
		}
	}
}
