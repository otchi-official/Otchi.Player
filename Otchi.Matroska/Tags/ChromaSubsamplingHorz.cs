using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChromaSubsamplingHorz : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChromaSubsamplingHorzId;
		public override string Name => "ChromaSubsamplingHorz";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\ChromaSubsamplingHorz)";
		public override string Description =>
			"The amount of pixels to remove in the Cr and Cb channels for every pixel not removed horizontally. Example: For video with 4:2:0 chroma subsampling, the ChromaSubsamplingHorz SHOULD be set to 1.";

		public ChromaSubsamplingHorz(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChromaSubsamplingHorzFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChromaSubsamplingHorzId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChromaSubsamplingHorz(dataSize, position, parent);
		}
	}
}
