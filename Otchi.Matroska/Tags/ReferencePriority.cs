using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ReferencePriority : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.ReferencePriorityId;
		public override string Name => "ReferencePriority";
		public override Path Path => "1*1(\\Segment\\Cluster\\BlockGroup\\ReferencePriority)";
		public override string Description =>
			"This frame is referenced and has the specified cache priority. In cache only a frame of the same or higher priority can replace this frame. A value of 0 means the frame is not referenced.";

		public ReferencePriority(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ReferencePriorityFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ReferencePriorityId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ReferencePriority(dataSize, position, parent);
		}
	}
}
