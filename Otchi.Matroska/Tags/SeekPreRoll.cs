using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SeekPreRoll : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.SeekPreRollId;
		public override string Name => "SeekPreRoll";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\SeekPreRoll)";
		public override string Description =>
			"After a discontinuity, SeekPreRoll is the duration in nanoseconds of the data the decoder MUST decode before the decoded data is valid.";

		public SeekPreRoll(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SeekPreRollFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SeekPreRollId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SeekPreRoll(dataSize, position, parent);
		}
	}
}
