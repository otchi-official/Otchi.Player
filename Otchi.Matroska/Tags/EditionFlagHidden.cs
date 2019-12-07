using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class EditionFlagHidden : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.EditionFlagHiddenId;
		public override string Name => "EditionFlagHidden";
		public override Path Path => "1*1(\\Segment\\Chapters\\EditionEntry\\EditionFlagHidden)";
		public override string Description =>
			"If an edition is hidden (1), it SHOULD NOT be available to the user interface (but still to Control Tracks; see";

		public EditionFlagHidden(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class EditionFlagHiddenFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.EditionFlagHiddenId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new EditionFlagHidden(dataSize, position, parent);
		}
	}
}
