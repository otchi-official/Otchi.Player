using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class NameElement : StringElement
	{
		public override VInt Id => MatroskaIds.NameId;
		public override string Name => "Name";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Name)";
		public override string Description =>
			"A human-readable track name.";

		public NameElement(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class NameElementFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.NameId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new NameElement(dataSize, position, parent);
		}
	}
}
