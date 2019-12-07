using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Tracks : MasterElement
	{
		public override VInt Id => MatroskaIds.TracksId;
		public override string Name => "Tracks";
		public override Path Path => "0*(\\Segment\\Tracks)";
		public override string Description =>
			"A Top-Level Element of information with many tracks described.";

		public Tracks(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TracksFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TracksId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Tracks(dataSize, position, parent);
		}
	}
}
