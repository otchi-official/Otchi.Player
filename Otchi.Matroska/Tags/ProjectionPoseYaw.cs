using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ProjectionPoseYaw : DoubleElement
	{
		public override VInt Id => MatroskaIds.ProjectionPoseYawId;
		public override string Name => "ProjectionPoseYaw";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\Projection\\ProjectionPoseYaw)";
		public override string Description =>
			"Specifies a yaw rotation to the projection.";

		public ProjectionPoseYaw(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ProjectionPoseYawFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ProjectionPoseYawId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ProjectionPoseYaw(dataSize, position, parent);
		}
	}
}
