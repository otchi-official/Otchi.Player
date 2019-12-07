using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class DocTypeReadVersion : UnsignedIntElement
    {
        internal DocTypeReadVersion(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.DocTypeReadVersionId;
        public override string Name => "DocTypeReadVersion";
        public override Path Path => "1*1(\\EBML\\DocTypeReadVersion)";
        public override bool ValidateValue => Value != 0;

        public override string Description =>
            "The minimum DocType version an EBML Reader has to support to read this EBML Document. " +
            "The value of the DocTypeReadVersion Element MUST be less than or equal " +
            "to the value of the DocTypeVersion Element.";
    }

    public class DocTypeReadVersionFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.DocTypeReadVersionId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new DocTypeReadVersion(dataSize, position, parent);
        }
    }
}