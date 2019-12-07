using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SamplingFrequency : DoubleElement
	{
		public override VInt Id => MatroskaIds.SamplingFrequencyId;
		public override string Name => "SamplingFrequency";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Audio\\SamplingFrequency)";
		public override string Description =>
			"Sampling frequency in Hz.";

		public SamplingFrequency(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SamplingFrequencyFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SamplingFrequencyId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SamplingFrequency(dataSize, position, parent);
		}
	}
}
