using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public static class EbmlIds
    {
        public static VInt EbmlHeadId => 0x1A45DFA3;
        public static VInt EbmlVersionId => 0x4286;
        public static VInt EbmlReadVersionId => 0x42F7;
        public static VInt EbmlMaxIdLengthId => 0x42F2;
        public static VInt EbmlMaxSizeLengthId => 0x42F3;
        public static VInt DocTypeId => 0x4282;
        public static VInt DocTypeVersionId => 0x4287;
        public static VInt DocTypeReadVersionId => 0x4285;
        public static VInt DocTypeExtensionId => 0x4281;
        public static VInt DocTypeExtensionNameId => 0x4283;
        public static VInt DocTypeExtensionVersionId => 0x4284;
    }
}