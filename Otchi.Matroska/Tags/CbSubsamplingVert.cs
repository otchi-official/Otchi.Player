using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CbSubsamplingVert : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CbSubsamplingVertId;
		public override string Name => "CbSubsamplingVert";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\CbSubsamplingVert)";
		public override string Description =>
			"The amount of pixels to remove in the Cb channel for every pixel not removed vertically. This is additive with ChromaSubsamplingVert.";

		public CbSubsamplingVert(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CbSubsamplingVertFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CbSubsamplingVertId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CbSubsamplingVert(dataSize, position, parent);
		}
	}
}
