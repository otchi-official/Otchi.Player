using System.IO;
using System.Threading.Tasks;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;
using Path = Otchi.Ebml.Types.Path;

namespace Otchi.Matroska.Tags
{
	public class DateUTC : DateElement
	{
		public override VInt Id => MatroskaIds.DateUTCId;
		public override string Name => "DateUTC";
		public override Path Path => "0*1(\\Segment\\Info\\DateUTC)";
		public override string Description =>
			"The date and time that the Segment was created by the muxing application or library.";

		public DateUTC(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}
    }

	public class DateUTCFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.DateUTCId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new DateUTC(dataSize, position, parent);
		}
	}
}
