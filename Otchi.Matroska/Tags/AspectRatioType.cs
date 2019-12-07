using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class AspectRatioType : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.AspectRatioTypeId;
		public override string Name => "AspectRatioType";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\AspectRatioType)";
		public override string Description =>
			"Specify the possible modifications to the aspect ratio.";

		public AspectRatioType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AspectRatioTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AspectRatioTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new AspectRatioType(dataSize, position, parent);
		}
	}
}
