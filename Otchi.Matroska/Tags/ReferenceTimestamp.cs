using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ReferenceTimestamp : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ReferenceTimestampId;
		public override string Name => "ReferenceTimestamp";
		public override Path Path => "1*1(\\Segment\\Cluster\\BlockGroup\\ReferenceFrame\\ReferenceTimestamp)";
		public override string Description =>
			"";

		public ReferenceTimestamp(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ReferenceTimestampFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ReferenceTimestampId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ReferenceTimestamp(dataSize, position, parent);
		}
	}
}
