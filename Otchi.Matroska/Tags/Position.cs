using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Position : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PositionId;
		public override string Name => "Position";
		public override Path Path => "0*1(\\Segment\\Cluster\\Position)";
		public override string Description =>
			"The Segment Position of the Cluster in the Segment (0 in live streams). It might help to resynchronise offset on damaged streams.";

		public Position(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PositionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PositionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Position(dataSize, position, parent);
		}
	}
}
