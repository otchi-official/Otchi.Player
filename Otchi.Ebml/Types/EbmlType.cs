using System.ComponentModel;

namespace Otchi.Ebml.Types
{
    public enum EbmlType
    {
        [Description("Signed Integer")]
        SignedInteger,
        [Description("Unsigned Integer")]
        UnsignedInteger,
        [Description("DoubleType")]
        DoubleType,
        [Description("StringType")]
        StringType,
        [Description("Utf8")]
        Utf8,
        [Description("Date")]
        Date,
        [Description("Master")]
        Master,
        [Description("Binary")]
        Binary
    }
}