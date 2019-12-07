using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueBlockNumber : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueBlockNumberId;
		public override string Name => "CueBlockNumber";
		public override Path Path => "0*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueBlockNumber)";
		public override string Description =>
			"Number of the Block in the specified Cluster.";

		public CueBlockNumber(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueBlockNumberFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueBlockNumberId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueBlockNumber(dataSize, position, parent);
		}
	}
}
