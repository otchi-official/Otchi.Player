using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackNumber : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackNumberId;
		public override string Name => "TrackNumber";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackNumber)";
		public override string Description =>
			"The track number as used in the Block Header (using more than 127 tracks is not encouraged, though the design allows an unlimited number).";

		public TrackNumber(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackNumberFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackNumberId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackNumber(dataSize, position, parent);
		}
	}
}
