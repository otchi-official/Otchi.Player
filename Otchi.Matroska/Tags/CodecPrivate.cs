using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CodecPrivate : BinaryElement
	{
		public override VInt Id => MatroskaIds.CodecPrivateId;
		public override string Name => "CodecPrivate";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\CodecPrivate)";
		public override string Description =>
			"Private data only known to the codec.";

		public CodecPrivate(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CodecPrivateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CodecPrivateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CodecPrivate(dataSize, position, parent);
		}
	}
}
