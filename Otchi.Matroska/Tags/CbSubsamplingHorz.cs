using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CbSubsamplingHorz : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CbSubsamplingHorzId;
		public override string Name => "CbSubsamplingHorz";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\CbSubsamplingHorz)";
		public override string Description =>
			"The amount of pixels to remove in the Cb channel for every pixel not removed horizontally. This is additive with ChromaSubsamplingHorz. Example: For video with 4:2:1 chroma subsampling, the ChromaSubsamplingHorz SHOULD be set to 1 and CbSubsamplingHorz SHOULD be set to 1.";

		public CbSubsamplingHorz(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CbSubsamplingHorzFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CbSubsamplingHorzId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CbSubsamplingHorz(dataSize, position, parent);
		}
	}
}
