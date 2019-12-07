using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class DefaultDecodedFieldDuration : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.DefaultDecodedFieldDurationId;
		public override string Name => "DefaultDecodedFieldDuration";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\DefaultDecodedFieldDuration)";
		public override string Description =>
			"The period in nanoseconds (not scaled by TimestampScale) between two successive fields at the output of the decoding process (see";

		public DefaultDecodedFieldDuration(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DefaultDecodedFieldDurationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DefaultDecodedFieldDurationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DefaultDecodedFieldDuration(dataSize, position, parent);
		}
	}
}
