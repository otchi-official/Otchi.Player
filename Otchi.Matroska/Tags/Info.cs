using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class Info : MasterElement
	{
		public override VInt Id => MatroskaIds.InfoId;
		public override string Name => "Info";
		public override Path Path => "1*(\\Segment\\Info)";
		public override string Description =>
			"Contains general information about the Segment.";

		public Info(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class InfoFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.InfoId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new Info(dataSize, position, parent);
		}
	}
}
