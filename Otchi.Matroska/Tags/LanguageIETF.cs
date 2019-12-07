using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class LanguageIETF : StringElement
	{
		public override VInt Id => MatroskaIds.LanguageIETFId;
		public override string Name => "LanguageIETF";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\LanguageIETF)";
		public override string Description =>
			"Specifies the language of the track according to";

		public LanguageIETF(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class LanguageIETFFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.LanguageIETFId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new LanguageIETF(dataSize, position, parent);
		}
	}
}
