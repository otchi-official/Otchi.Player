using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueRefNumber : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueRefNumberId;
		public override string Name => "CueRefNumber";
		public override Path Path => "0*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueReference\\CueRefNumber)";
		public override string Description =>
			"Number of the referenced Block of Track X in the specified Cluster.";

		public CueRefNumber(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueRefNumberFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueRefNumberId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueRefNumber(dataSize, position, parent);
		}
	}
}
