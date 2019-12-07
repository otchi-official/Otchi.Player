using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterTranslateEditionUID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterTranslateEditionUIDId;
		public override string Name => "ChapterTranslateEditionUID";
		public override Path Path => "0*(\\Segment\\Info\\ChapterTranslate\\ChapterTranslateEditionUID)";
		public override string Description =>
			"Specify an edition UID on which this correspondence applies. When not specified, it means for all editions found in the Segment.";

		public ChapterTranslateEditionUID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterTranslateEditionUIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterTranslateEditionUIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterTranslateEditionUID(dataSize, position, parent);
		}
	}
}
