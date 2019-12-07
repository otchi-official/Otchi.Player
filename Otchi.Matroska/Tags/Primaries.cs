using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Primaries : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.PrimariesId;
		public override string Name => "Primaries";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\Primaries)";
		public override string Description =>
			"The colour primaries of the video. For clarity, the value and meanings for Primaries are adopted from Table 2 of ISO/IEC 23091-4 or ITU-T H.273.";

		public Primaries(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrimariesFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrimariesId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Primaries(dataSize, position, parent);
		}
	}
}
