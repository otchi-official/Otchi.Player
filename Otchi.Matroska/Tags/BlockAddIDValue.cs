using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAddIDValue : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.BlockAddIDValueId;
		public override string Name => "BlockAddIDValue";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\BlockAdditionMapping\\BlockAddIDValue)";
		public override string Description =>
			"The";

		public BlockAddIDValue(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAddIDValueFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAddIDValueId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAddIDValue(dataSize, position, parent);
		}
	}
}
