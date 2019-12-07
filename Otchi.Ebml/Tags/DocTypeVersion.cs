using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class DocTypeVersion : UnsignedIntElement
    {
        internal DocTypeVersion(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.DocTypeVersionId;
        public override string Name => "DocTypeVersion";
        public override Path Path => "1*1(\\EBML\\DocTypeVersion)";
        public override bool ValidateValue => Value != 0;
        public override string Description => "The version of DocType interpreter used to create the EBML Document.";
    }

    public class DocTypeVersionFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.DocTypeVersionId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new DocTypeVersion(dataSize, position, parent);
        }
    }
}