using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SimpleBlock : BinaryElement
	{
		public override VInt Id => MatroskaIds.SimpleBlockId;
		public override string Name => "SimpleBlock";
		public override Path Path => "0*(\\Segment\\Cluster\\SimpleBlock)";
		public override string Description =>
			"Similar to";

		public SimpleBlock(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SimpleBlockFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SimpleBlockId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SimpleBlock(dataSize, position, parent);
		}
	}
}
