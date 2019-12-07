using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Colour : MasterElement
	{
		public override VInt Id => MatroskaIds.ColourId;
		public override string Name => "Colour";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour)";
		public override string Description =>
			"Settings describing the colour format.";

		public Colour(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ColourFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ColourId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Colour(dataSize, position, parent);
		}
	}
}
