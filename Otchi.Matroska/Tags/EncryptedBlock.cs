using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class EncryptedBlock : BinaryElement
	{
		public override VInt Id => MatroskaIds.EncryptedBlockId;
		public override string Name => "EncryptedBlock";
		public override Path Path => "0*(\\Segment\\Cluster\\EncryptedBlock)";
		public override string Description =>
			"Similar to";

		public EncryptedBlock(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class EncryptedBlockFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.EncryptedBlockId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new EncryptedBlock(dataSize, position, parent);
		}
	}
}
