using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Timestamp : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TimestampId;
		public override string Name => "Timestamp";
		public override Path Path => "1*1(\\Segment\\Cluster\\Timestamp)";
		public override string Description =>
			"Absolute timestamp of the cluster (based on TimestampScale).";

		public Timestamp(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TimestampFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TimestampId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Timestamp(dataSize, position, parent);
		}
	}
}
