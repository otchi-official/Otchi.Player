using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueTrack : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueTrackId;
		public override string Name => "CueTrack";
		public override Path Path => "1*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueTrack)";
		public override string Description =>
			"The track for which a position is given.";

		public CueTrack(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueTrackFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueTrackId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueTrack(dataSize, position, parent);
		}
	}
}
