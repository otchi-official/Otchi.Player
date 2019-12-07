using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class SeekPosition : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.SeekPositionId;
		public override string Name => "SeekPosition";
		public override Path Path => "1*1(\\Segment\\SeekHead\\Seek\\SeekPosition)";
		public override string Description =>
			"The Segment Position of the Element.";

		public SeekPosition(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class SeekPositionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SeekPositionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SeekPosition(dataSize, position, parent);
		}
	}
}
