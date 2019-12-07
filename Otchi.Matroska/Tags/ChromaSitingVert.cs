using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChromaSitingVert : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChromaSitingVertId;
		public override string Name => "ChromaSitingVert";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\ChromaSitingVert)";
		public override string Description =>
			"How chroma is subsampled vertically.";

		public ChromaSitingVert(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChromaSitingVertFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChromaSitingVertId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChromaSitingVert(dataSize, position, parent);
		}
	}
}
