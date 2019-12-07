using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class AlphaMode : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.AlphaModeId;
		public override string Name => "AlphaMode";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\AlphaMode)";
		public override string Description =>
			"Alpha Video Mode. Presence of this Element indicates that the BlockAdditional Element could contain Alpha data.";

		public AlphaMode(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AlphaModeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AlphaModeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new AlphaMode(dataSize, position, parent);
		}
	}
}
