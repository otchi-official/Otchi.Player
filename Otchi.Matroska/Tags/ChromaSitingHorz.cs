using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChromaSitingHorz : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChromaSitingHorzId;
		public override string Name => "ChromaSitingHorz";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\ChromaSitingHorz)";
		public override string Description =>
			"How chroma is subsampled horizontally.";

		public ChromaSitingHorz(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChromaSitingHorzFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChromaSitingHorzId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChromaSitingHorz(dataSize, position, parent);
		}
	}
}
