using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MatrixCoefficients : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.MatrixCoefficientsId;
		public override string Name => "MatrixCoefficients";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MatrixCoefficients)";
		public override string Description =>
			"The Matrix Coefficients of the video used to derive luma and chroma values from red, green, and blue color primaries. For clarity, the value and meanings for MatrixCoefficients are adopted from Table 4 of ISO/IEC 23001-8:2016 or ITU-T H.273.";

		public MatrixCoefficients(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MatrixCoefficientsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MatrixCoefficientsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MatrixCoefficients(dataSize, position, parent);
		}
	}
}
