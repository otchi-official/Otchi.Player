using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ProjectionPoseRoll : DoubleElement
	{
		public override VInt Id => MatroskaIds.ProjectionPoseRollId;
		public override string Name => "ProjectionPoseRoll";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\Projection\\ProjectionPoseRoll)";
		public override string Description =>
			"Specifies a roll rotation to the projection.";

		public ProjectionPoseRoll(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ProjectionPoseRollFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ProjectionPoseRollId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ProjectionPoseRoll(dataSize, position, parent);
		}
	}
}
