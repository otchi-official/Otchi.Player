using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChromaSubsamplingVert : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChromaSubsamplingVertId;
		public override string Name => "ChromaSubsamplingVert";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\ChromaSubsamplingVert)";
		public override string Description =>
			"The amount of pixels to remove in the Cr and Cb channels for every pixel not removed vertically. Example: For video with 4:2:0 chroma subsampling, the ChromaSubsamplingVert SHOULD be set to 1.";

		public ChromaSubsamplingVert(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChromaSubsamplingVertFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChromaSubsamplingVertId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChromaSubsamplingVert(dataSize, position, parent);
		}
	}
}
