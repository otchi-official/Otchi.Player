using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class FlagEnabled : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.FlagEnabledId;
		public override string Name => "FlagEnabled";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\FlagEnabled)";
		public override string Description =>
			"Set if the track is usable. (1 bit)";

		public FlagEnabled(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class FlagEnabledFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.FlagEnabledId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new FlagEnabled(dataSize, position, parent);
		}
	}
}
