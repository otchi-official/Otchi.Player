using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueTrackPositions : MasterElement
	{
		public override VInt Id => MatroskaIds.CueTrackPositionsId;
		public override string Name => "CueTrackPositions";
		public override Path Path => "1*(\\Segment\\Cues\\CuePoint\\CueTrackPositions)";
		public override string Description =>
			"Contain positions for different tracks corresponding to the timestamp.";

		public CueTrackPositions(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueTrackPositionsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueTrackPositionsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueTrackPositions(dataSize, position, parent);
		}
	}
}
