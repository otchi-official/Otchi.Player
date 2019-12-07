using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class PrevFilename : StringElement
	{
		public override VInt Id => MatroskaIds.PrevFilenameId;
		public override string Name => "PrevFilename";
		public override Path Path => "0*1(\\Segment\\Info\\PrevFilename)";
		public override string Description =>
			"Provision of the previous filename is for display convenience, but PrevUID SHOULD be considered authoritative for identifying the previous Segment in a Linked Segment.";

		public PrevFilename(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class PrevFilenameFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.PrevFilenameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new PrevFilename(dataSize, position, parent);
		}
	}
}
