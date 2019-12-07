using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Video : MasterElement
	{
		public override VInt Id => MatroskaIds.VideoId;
		public override string Name => "Video";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video)";
		public override string Description =>
			"Video settings.";

		public Video(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class VideoFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.VideoId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Video(dataSize, position, parent);
		}
	}
}
