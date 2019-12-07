using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class EbmlReadVersion : UnsignedIntElement
    {
        internal EbmlReadVersion(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.EbmlReadVersionId;
        public override string Name => "EBMLReadVersion";
        public override Path Path => "1*1(\\EBML\\EBMLReadVersion)";
        public override string Description =>
            "The minimum EBML version an EBML Reader has to support to read this EBML Document. " +
            "The EBMLReadVersion Element MUST be less than or equal to EBMLVersion.";
    }

    public class EbmlReadVersionFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.EbmlReadVersionId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new EbmlReadVersion(dataSize, position, parent);
        }
    }
}