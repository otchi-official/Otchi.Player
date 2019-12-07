using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackTranslateCodec : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.TrackTranslateCodecId;
		public override string Name => "TrackTranslateCodec";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\TrackTranslate\\TrackTranslateCodec)";
		public override string Description =>
			"The";

		public TrackTranslateCodec(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackTranslateCodecFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackTranslateCodecId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackTranslateCodec(dataSize, position, parent);
		}
	}
}
