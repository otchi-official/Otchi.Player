using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Matroska.Tags
{
	public class AESSettingsCipherMode : UnsignedIntElement
	{
		public override VInt Id => MatroskaIds.AESSettingsCipherModeId;
		public override string Name => "AESSettingsCipherMode";
		public override Path Path => "1*1(\\Segment\\Tracks\\TrackEntry\\ContentEncodings\\ContentEncoding\\ContentEncryption\\ContentEncAESSettings\\AESSettingsCipherMode)";
		public override string Description =>
			"The AES cipher mode used in the encryption.";

		public AESSettingsCipherMode(VInt dataSize, long position, EbmlElement? parent)
			: base(dataSize, position, parent)
		{
		}

	}

	public class AESSettingsCipherModeFactory : EbmlElementFactory
	{
		public override VInt Id => MatroskaIds.AESSettingsCipherModeId;

		public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
		{
			return new AESSettingsCipherMode(dataSize, position, parent);
		}
	}
}
