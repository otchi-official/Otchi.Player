using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Cues : MasterElement
	{
		public override VInt Id => MatroskaIds.CuesId;
		public override string Name => "Cues";
		public override Path Path => "0*1(\\Segment\\Cues)";
		public override string Description =>
			"A Top-Level Element to speed seeking access. All entries are local to the Segment.";

		public Cues(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CuesFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CuesId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Cues(dataSize, position, parent);
		}
	}
}
