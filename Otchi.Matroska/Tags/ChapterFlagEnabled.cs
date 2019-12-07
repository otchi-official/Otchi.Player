using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ChapterFlagEnabled : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ChapterFlagEnabledId;
		public override string Name => "ChapterFlagEnabled";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\ChapterAtom\\ChapterFlagEnabled)";
		public override string Description =>
			"Specify whether the chapter is enabled. It can be enabled/disabled by a Control Track. When disabled, the movie SHOULD skip all the content between the TimeStart and TimeEnd of this chapter (see";

		public ChapterFlagEnabled(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ChapterFlagEnabledFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ChapterFlagEnabledId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ChapterFlagEnabled(dataSize, position, parent);
		}
	}
}
