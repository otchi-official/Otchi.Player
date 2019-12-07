using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueDuration : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueDurationId;
		public override string Name => "CueDuration";
		public override Path Path => "0*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueDuration)";
		public override string Description =>
			"The duration of the block according to the Segment time base. If missing the track's DefaultDuration does not apply and no duration information is available in terms of the cues.";

		public CueDuration(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueDurationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueDurationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueDuration(dataSize, position, parent);
		}
	}
}
