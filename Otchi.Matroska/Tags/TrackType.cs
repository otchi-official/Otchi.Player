using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackType : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackTypeId;
		public override string Name => "TrackType";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackType)";
		public override string Description =>
			"A set of track types coded on 8 bits.";

		public TrackType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackType(dataSize, position, parent);
		}
	}
}
