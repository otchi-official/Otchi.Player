using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ProjectionPosePitch : DoubleElement
	{
		public override VInt Id => MatroskaIds.ProjectionPosePitchId;
		public override string Name => "ProjectionPosePitch";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\Projection\\ProjectionPosePitch)";
		public override string Description =>
			"Specifies a pitch rotation to the projection.";

		public ProjectionPosePitch(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ProjectionPosePitchFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ProjectionPosePitchId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ProjectionPosePitch(dataSize, position, parent);
		}
	}
}
