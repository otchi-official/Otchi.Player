using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class EbmlVersion : UnsignedIntElement
    {
        public EbmlVersion(VInt dataSize, long position, EbmlElement? parent) : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.EbmlVersionId;
        public override string Name => "EBMLVersion";
        public override Path Path => "1*1(\\EBML\\EBMLVersion)";
        public override string Description =>
            "The version of EBML specifications used to create the EBML Document. " +
            "The version of EBML defined in this document is 1, so EBMLVersion SHOULD be 1.";

        public override bool ValidateValue => Value != 0;
    }


    public class EbmlVersionFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.EbmlVersionId;
        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new EbmlVersion(dataSize, position, parent);
        }
    }
}