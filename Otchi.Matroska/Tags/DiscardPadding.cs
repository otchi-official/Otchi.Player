using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class DiscardPadding : IntElement
	{
		public override VInt Id => MatroskaIds.DiscardPaddingId;
		public override string Name => "DiscardPadding";
		public override Path Path => "0*1(\\Segment\\Cluster\\BlockGroup\\DiscardPadding)";
		public override string Description =>
			"Duration in nanoseconds of the silent data added to the Block (padding at the end of the Block for positive value, at the beginning of the Block for negative value). The duration of DiscardPadding is not calculated in the duration of the TrackEntry and SHOULD be discarded during playback.";

		public DiscardPadding(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class DiscardPaddingFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DiscardPaddingId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DiscardPadding(dataSize, position, parent);
		}
	}
}
