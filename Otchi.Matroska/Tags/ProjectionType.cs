using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ProjectionType : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ProjectionTypeId;
		public override string Name => "ProjectionType";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\Video\\Projection\\ProjectionType)";
		public override string Description =>
			"Describes the projection used for this video track.";

		public ProjectionType(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ProjectionTypeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ProjectionTypeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ProjectionType(dataSize, position, parent);
		}
	}
}
