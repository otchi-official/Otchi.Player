using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class GammaValue : DoubleElement
	{
		public override VInt Id => MatroskaIds.GammaValueId;
		public override string Name => "GammaValue";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\GammaValue)";
		public override string Description =>
			"Gamma Value.";

		public GammaValue(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class GammaValueFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.GammaValueId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new GammaValue(dataSize, position, parent);
		}
	}
}
