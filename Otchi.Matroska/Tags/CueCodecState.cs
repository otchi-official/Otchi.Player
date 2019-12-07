using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueCodecState : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueCodecStateId;
		public override string Name => "CueCodecState";
		public override Path Path => "0*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueCodecState)";
		public override string Description =>
			"The Segment Position of the Codec State corresponding to this Cue Element. 0 means that the data is taken from the initial Track Entry.";

		public CueCodecState(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueCodecStateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueCodecStateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueCodecState(dataSize, position, parent);
		}
	}
}
