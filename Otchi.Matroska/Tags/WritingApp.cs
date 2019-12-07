using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class WritingApp : StringElement
	{
		public override VInt Id => MatroskaIds.WritingAppId;
		public override string Name => "WritingApp";
		public override Path Path => "1*1(\\Segment\\Info\\WritingApp)";
		public override string Description =>
			"Include the full name of the application followed by the version number.";

		public WritingApp(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class WritingAppFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.WritingAppId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new WritingApp(dataSize, position, parent);
		}
	}
}
