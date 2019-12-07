using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class DocTypeExtensionName : StringElement
    {
        internal DocTypeExtensionName(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.DocTypeExtensionNameId;
        public override string Name => "DocTypeExtensionName";
        public override Path Path => "1*1(\\EBML\\DocTypeExtension\\Name)";
        public override bool ValidateValue => Value?.Length > 0;

        public override string Description =>
            "The name of the DocTypeExtension to differentiate it from other DocTypeExtension " +
            "of the same DocType+DocTypeVersion tuple. " +
            "A DocTypeExtensionName value MUST be unique within the EBML Header.";
    }

    public class DocTypeExtensionNameFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.DocTypeExtensionNameId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new DocTypeExtensionName(dataSize, position, parent);
        }
    }
}