using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Otchi.Ebml;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Exceptions;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;
using Path = Otchi.Ebml.Types.Path;

namespace Otchi.Matroska.Tags
{
	public class SeekID : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.SeekIDId;
		public override string Name => "SeekID";
		public override Path Path => "1*1(\\Segment\\SeekHead\\Seek\\SeekID)";
		public override string Description =>
			"The binary ID corresponding to the Element name.";

        public SeekID(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}
    }

	public class SeekIDFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.SeekIDId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new SeekID(dataSize, position, parent);
		}
	}
}
