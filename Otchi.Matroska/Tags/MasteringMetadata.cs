using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MasteringMetadata : MasterElement
	{
		public override VInt Id => MatroskaIds.MasteringMetadataId;
		public override string Name => "MasteringMetadata";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Colour\\MasteringMetadata)";
		public override string Description =>
			"SMPTE 2086 mastering data.";

		public MasteringMetadata(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MasteringMetadataFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MasteringMetadataId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MasteringMetadata(dataSize, position, parent);
		}
	}
}
