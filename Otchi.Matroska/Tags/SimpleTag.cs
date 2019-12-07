using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SimpleTag : MasterElement
	{
		public override VInt Id => MatroskaIds.SimpleTagId;
		public override string Name => "SimpleTag";
		public override Path Path => "1*(\\Segment\\Tags\\Tag(1*(\\SimpleTag)))";
		public override string Description =>
			"Contains general information about the target.";

		public SimpleTag(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SimpleTagFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SimpleTagId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SimpleTag(dataSize, position, parent);
		}
	}
}
