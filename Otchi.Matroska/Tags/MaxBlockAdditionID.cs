using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MaxBlockAdditionID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.MaxBlockAdditionIDId;
		public override string Name => "MaxBlockAdditionID";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\MaxBlockAdditionID)";
		public override string Description =>
			"The maximum value of";

		public MaxBlockAdditionID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MaxBlockAdditionIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MaxBlockAdditionIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MaxBlockAdditionID(dataSize, position, parent);
		}
	}
}
