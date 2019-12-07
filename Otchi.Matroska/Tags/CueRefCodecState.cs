using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueRefCodecState : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueRefCodecStateId;
		public override string Name => "CueRefCodecState";
		public override Path Path => "0*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueReference\\CueRefCodecState)";
		public override string Description =>
			"The Segment Position of the Codec State corresponding to this referenced Element. 0 means that the data is taken from the initial Track Entry.";

		public CueRefCodecState(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueRefCodecStateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueRefCodecStateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueRefCodecState(dataSize, position, parent);
		}
	}
}
