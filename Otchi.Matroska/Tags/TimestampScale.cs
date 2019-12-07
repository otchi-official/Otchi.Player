using System.Runtime.CompilerServices;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TimestampScale : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TimestampScaleId;
		public override string Name => "TimestampScale";
		public override Path Path => "1*1(\\Segment\\Info\\TimestampScale)";
		public override string Description =>
			"Timestamp scale in nanoseconds (1.000.000 means all timestamps in the Segment are expressed in milliseconds).";

		public TimestampScale(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TimestampScaleFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TimestampScaleId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new TimestampScale(dataSize, position, parent);
        }
    }
}
