using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class MuxingApp : StringElement
	{
		public override VInt Id => MatroskaIds.MuxingAppId;
		public override string Name => "MuxingApp";
		public override Path Path => "1*1(\\Segment\\Info\\MuxingApp)";
		public override string Description =>
			"Include the full name of the application or library followed by the version number.";

		public MuxingApp(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class MuxingAppFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.MuxingAppId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new MuxingApp(dataSize, position, parent);
		}
	}
}
