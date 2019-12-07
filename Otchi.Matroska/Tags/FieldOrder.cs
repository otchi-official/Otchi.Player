using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FieldOrder : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FieldOrderId;
		public override string Name => "FieldOrder";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\FieldOrder)";
		public override string Description =>
			"Bottom field displayed first. Fields are interleaved in storage with the top line of the top field stored first.";

		public FieldOrder(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FieldOrderFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FieldOrderId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FieldOrder(dataSize, position, parent);
		}
	}
}
