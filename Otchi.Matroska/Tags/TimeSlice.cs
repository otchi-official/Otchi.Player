using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TimeSlice : MasterElement
	{
		public override VInt Id => MatroskaIds.TimeSliceId;
		public override string Name => "TimeSlice";
		public override Path Path => "0*(\\Segment\\Cluster\\BlockGroup\\Slices\\TimeSlice)";
		public override string Description =>
			"Contains extra time information about the data contained in the Block. Being able to interpret this Element is not REQUIRED for playback.";

		public TimeSlice(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TimeSliceFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TimeSliceId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TimeSlice(dataSize, position, parent);
		}
	}
}
