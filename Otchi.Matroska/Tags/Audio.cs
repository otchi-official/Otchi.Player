using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Audio : MasterElement
	{
		public override VInt Id => MatroskaIds.AudioId;
		public override string Name => "Audio";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Audio)";
		public override string Description =>
			"Audio settings.";

		public Audio(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AudioFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AudioId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Audio(dataSize, position, parent);
		}
	}
}
