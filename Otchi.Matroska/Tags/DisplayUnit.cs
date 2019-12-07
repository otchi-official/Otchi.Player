using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class DisplayUnit : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.DisplayUnitId;
		public override string Name => "DisplayUnit";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\DisplayUnit)";
		public override string Description =>
			"How DisplayWidth & DisplayHeight are interpreted.";

		public DisplayUnit(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DisplayUnitFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DisplayUnitId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DisplayUnit(dataSize, position, parent);
		}
	}
}
