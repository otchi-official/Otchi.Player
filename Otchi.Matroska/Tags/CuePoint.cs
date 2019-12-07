using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CuePoint : MasterElement
	{
		public override VInt Id => MatroskaIds.CuePointId;
		public override string Name => "CuePoint";
		public override Path Path => "1*(\\Segment\\Cues\\CuePoint)";
		public override string Description =>
			"Contains all information relative to a seek point in the Segment.";

		public CuePoint(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CuePointFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CuePointId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CuePoint(dataSize, position, parent);
		}
	}
}
