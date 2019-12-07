using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class EbmlMaxIdLength : UnsignedIntElement
    {
        internal EbmlMaxIdLength(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.EbmlMaxIdLengthId;
        public override string Name => "EBMLMaxIdLength";
        public override Path Path => "1*1(\\EBML\\EBMLMaxIDLength)";
        public override bool ValidateValue => Value >= 4;
        public override string Description =>
            "The EBMLMaxIDLength Element stores the maximum permitted " +
            "length in octets of the Element IDs to be found within the EBML Body. " +
            "An EBMLMaxIDLength Element value of four is RECOMMENDED, " +
            "though larger values are allowed.";
    }

    public class EbmlMaxIdLengthFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.EbmlMaxIdLengthId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new EbmlMaxIdLength(dataSize, position, parent);
        }
    }
}