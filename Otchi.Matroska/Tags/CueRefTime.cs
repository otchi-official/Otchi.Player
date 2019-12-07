using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueRefTime : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueRefTimeId;
		public override string Name => "CueRefTime";
		public override Path Path => "1*1(\\Segment\\Cues\\CuePoint\\CueTrackPositions\\CueReference\\CueRefTime)";
		public override string Description =>
			"Timestamp of the referenced Block.";

		public CueRefTime(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueRefTimeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueRefTimeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueRefTime(dataSize, position, parent);
		}
	}
}
