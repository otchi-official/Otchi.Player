using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SilentTrackNumber : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.SilentTrackNumberId;
		public override string Name => "SilentTrackNumber";
		public override Path Path => "0*(\\Segment\\Cluster\\SilentTracks\\SilentTrackNumber)";
		public override string Description =>
			"One of the track number that are not used from now on in the stream. It could change later if not specified as silent in a further Cluster.";

		public SilentTrackNumber(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SilentTrackNumberFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SilentTrackNumberId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SilentTrackNumber(dataSize, position, parent);
		}
	}
}
