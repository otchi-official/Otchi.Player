using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TransferCharacteristics : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TransferCharacteristicsId;
		public override string Name => "TransferCharacteristics";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\TransferCharacteristics)";
		public override string Description =>
			"The transfer characteristics of the video. For clarity, the value and meanings for TransferCharacteristics are adopted from Table 3 of  ISO/IEC 23091-4 or ITU-T H.273.";

		public TransferCharacteristics(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TransferCharacteristicsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TransferCharacteristicsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TransferCharacteristics(dataSize, position, parent);
		}
	}
}
