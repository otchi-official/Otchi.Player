using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackUIDId;
		public override string Name => "TrackUID";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackUID)";
		public override string Description =>
			"A unique ID to identify the Track. This SHOULD be kept the same when making a direct stream copy of the Track to another file.";

		public TrackUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackUID(dataSize, position, parent);
		}
	}
}
