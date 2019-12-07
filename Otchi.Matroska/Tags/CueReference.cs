using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueReference : MasterElement
	{
		public override VInt Id => MatroskaIds.CueReferenceId;
		public override string Name => "CueReference";
		public override Path Path => "0*(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueReference)";
		public override string Description =>
			"The Clusters containing the referenced Blocks.";

		public CueReference(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueReferenceFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueReferenceId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueReference(dataSize, position, parent);
		}
	}
}
