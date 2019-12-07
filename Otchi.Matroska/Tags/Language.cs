using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Language : StringElement
	{
		public override VInt Id => MatroskaIds.LanguageId;
		public override string Name => "Language";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Language)";
		public override string Description =>
			"Specifies the language of the track in the";

		public Language(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class LanguageFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.LanguageId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Language(dataSize, position, parent);
		}
	}
}
