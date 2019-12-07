using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Duration : DoubleElement
	{
		public override VInt Id => MatroskaIds.DurationId;
		public override string Name => "Duration";
		public override Path Path => "0*1(\\Segment\\Info\\Duration)";
		public override string Description =>
			"Duration of the Segment in nanoseconds based on TimestampScale.";

		public Duration(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DurationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DurationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Duration(dataSize, position, parent);
		}
	}
}
