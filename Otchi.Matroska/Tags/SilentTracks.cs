using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SilentTracks : MasterElement
	{
		public override VInt Id => MatroskaIds.SilentTracksId;
		public override string Name => "SilentTracks";
		public override Path Path => "0*1(\\Segment\\Cluster\\SilentTracks)";
		public override string Description =>
			"The list of tracks that are not used in that part of the stream. It is useful when using overlay tracks on seeking or to decide what track to use.";

		public SilentTracks(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SilentTracksFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SilentTracksId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SilentTracks(dataSize, position, parent);
		}
	}
}
