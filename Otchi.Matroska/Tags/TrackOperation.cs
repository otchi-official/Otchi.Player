using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class TrackOperation : MasterElement
	{
		public override VInt Id => MatroskaIds.TrackOperationId;
		public override string Name => "TrackOperation";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\TrackOperation)";
		public override string Description =>
			"Operation that needs to be applied on tracks to create this virtual track. For more details";

		public TrackOperation(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class TrackOperationFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.TrackOperationId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new TrackOperation(dataSize, position, parent);
		}
	}
}
