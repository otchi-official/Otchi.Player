using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class BlockAddIDName : StringElement
	{
		public override VInt Id => MatroskaIds.BlockAddIDNameId;
		public override string Name => "BlockAddIDName";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\BlockAdditionMapping\\BlockAddIDName)";
		public override string Description =>
			"A human-friendly name describing the type of BlockAdditional data as defined by the associated Block Additional Mapping.";

		public BlockAddIDName(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class BlockAddIDNameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.BlockAddIDNameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new BlockAddIDName(dataSize, position, parent);
		}
	}
}
