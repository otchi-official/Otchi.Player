using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SeekHead : MasterElement
	{
		public override VInt Id => MatroskaIds.SeekHeadId;
		public override string Name => "SeekHead";
		public override Path Path => "0*2(\\Segment\\SeekHead)";
		public override string Description =>
			"Contains the Segment Position of other Top-Level Elements.";

		public SeekHead(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SeekHeadFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SeekHeadId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SeekHead(dataSize, position, parent);
		}
	}
}
