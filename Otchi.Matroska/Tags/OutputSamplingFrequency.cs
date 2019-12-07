using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class OutputSamplingFrequency : DoubleElement
	{
		public override VInt Id => MatroskaIds.OutputSamplingFrequencyId;
		public override string Name => "OutputSamplingFrequency";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Audio\\OutputSamplingFrequency)";
		public override string Description =>
			"Real output sampling frequency in Hz (used for SBR techniques).";

		public OutputSamplingFrequency(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class OutputSamplingFrequencyFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.OutputSamplingFrequencyId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new OutputSamplingFrequency(dataSize, position, parent);
		}
	}
}
