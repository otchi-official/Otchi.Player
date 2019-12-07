using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Projection : MasterElement
	{
		public override VInt Id => MatroskaIds.ProjectionId;
		public override string Name => "Projection";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\Video\\Projection)";
		public override string Description =>
			"Describes the video projection details. Used to render spherical and VR videos.";

		public Projection(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ProjectionFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ProjectionId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Projection(dataSize, position, parent);
		}
	}
}
