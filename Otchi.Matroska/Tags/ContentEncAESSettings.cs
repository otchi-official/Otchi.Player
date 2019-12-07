using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class ContentEncAESSettings : MasterElement
	{
		public override VInt Id => MatroskaIds.ContentEncAESSettingsId;
		public override string Name => "ContentEncAESSettings";
		public override Path Path => "0*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentEncAESSettings)";
		public override string Description =>
			"Settings describing the encryption algorithm used. If `ContentEncAlgo` != 5 this MUST be ignored.";

		public ContentEncAESSettings(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class ContentEncAESSettingsFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.ContentEncAESSettingsId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new ContentEncAESSettings(dataSize, position, parent);
		}
	}
}
