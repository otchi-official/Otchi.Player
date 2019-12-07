using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecState : BinaryElement
	{
		public override VInt Id => MatroskaIds.CodecStateId;
		public override string Name => "CodecState";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\CodecState)";
		public override string Description =>
			"The new codec state to use. Data interpretation is private to the codec. This information SHOULD always be referenced by a seek entry.";

		public CodecState(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecStateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecStateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecState(dataSize, position, parent);
		}
	}
}
