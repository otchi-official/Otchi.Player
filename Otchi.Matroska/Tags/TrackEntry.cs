using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackEntry : MasterElement
	{
		public override VInt Id => MatroskaIds.TrackEntryId;
		public override string Name => "TrackEntry";
		public override Path Path => "1*(\\Segment\\Tracks\\TrackEntry)";
		public override string Description =>
			"Describes a track with all Elements.";

		public TrackEntry(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackEntryFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackEntryId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackEntry(dataSize, position, parent);
		}
	}
}
