using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Slices : MasterElement
	{
		public override VInt Id => MatroskaIds.SlicesId;
		public override string Name => "Slices";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\Slices)";
		public override string Description =>
			"Contains slices description.";

		public Slices(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SlicesFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SlicesId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Slices(dataSize, position, parent);
		}
	}
}
