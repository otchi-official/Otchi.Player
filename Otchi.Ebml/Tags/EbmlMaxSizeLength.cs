using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class EbmlMaxSizeLength : UnsignedIntElement
    {
        internal EbmlMaxSizeLength(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.EbmlMaxSizeLengthId;
        public override string Name => "EBMLMaxSizeLength";
        public override Path Path => "1*1(\\EBML\\EBMLMaxSizeLength)";

        public override bool ValidateValue => Value != 0;

        public override string Description =>
            "The EBMLMaxSizeLength Element stores the maximum permitted length in octets of " +
            "the expressions of all Element Data Sizes to be found within the EBML Body. " +
            "The EBMLMaxSizeLength Element documents an upper bound for the length of all " +
            "Element Data ByteSize expressions within the EBML Body and not an upper bound for " +
            "the value of all Element Data ByteSize expressions within the EBML Body. " +
            "EBML Elements that have an Element Data ByteSize expression which is larger " +
            "in octets than what is expressed by EBMLMaxSizeLength Element are invalid.";
    }

    public class EbmlMaxSizeLengthFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.EbmlMaxSizeLengthId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new EbmlMaxSizeLength(dataSize, position, parent);
        }
    }
}