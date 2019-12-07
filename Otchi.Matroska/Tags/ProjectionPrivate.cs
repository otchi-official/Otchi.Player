using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ProjectionPrivate : BinaryElement
	{
		public override VInt Id => MatroskaIds.ProjectionPrivateId;
		public override string Name => "ProjectionPrivate";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Projection\\ProjectionPrivate)";
		public override string Description =>
			"Private data that only applies to a specific projection.";

		public ProjectionPrivate(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ProjectionPrivateFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ProjectionPrivateId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ProjectionPrivate(dataSize, position, parent);
		}
	}
}
