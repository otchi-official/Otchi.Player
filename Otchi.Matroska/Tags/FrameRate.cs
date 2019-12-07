using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FrameRate : DoubleElement
	{
		public override VInt Id => MatroskaIds.FrameRateId;
		public override string Name => "FrameRate";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\FrameRate)";
		public override string Description =>
			"Number of frames per second.";

		public FrameRate(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FrameRateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FrameRateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FrameRate(dataSize, position, parent);
		}
	}
}
