using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class CueTime : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.CueTimeId;
		public override string Name => "CueTime";
		public override Path Path => "1*1(\\Segment\\Cues\\CuePoint\\CueTime)";
		public override string Description =>
			"Absolute timestamp according to the Segment time base.";

		public CueTime(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class CueTimeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.CueTimeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new CueTime(dataSize, position, parent);
		}
	}
}
