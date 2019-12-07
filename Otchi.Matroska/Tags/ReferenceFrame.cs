using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ReferenceFrame : MasterElement
	{
		public override VInt Id => MatroskaIds.ReferenceFrameId;
		public override string Name => "ReferenceFrame";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\ReferenceFrame)";
		public override string Description =>
			"";

		public ReferenceFrame(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ReferenceFrameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ReferenceFrameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ReferenceFrame(dataSize, position, parent);
		}
	}
}
