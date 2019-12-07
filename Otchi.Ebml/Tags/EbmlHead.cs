using System.Linq;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using Otchi.Ebml.Types;

namespace Otchi.Ebml.Tags
{
    public class EbmlHead : MasterElement
    {
        internal EbmlHead(VInt dataSize, long position, EbmlElement? parent)
            : base(dataSize, position, parent)
        {
        }

        public override VInt Id => EbmlIds.EbmlHeadId;
        public override string Name => "EBML";
        public override Path Path => "1*1(\\EBML)1*1(\\EBML)";

        public override string Description =>
            "Set the EBML characteristics of the data to follow. Each EBML Document has to start with this.";

        public EbmlVersion? VersionElement =>
            (from value in this where value.Value.Id == EbmlIds.EbmlVersionId select value.Value).FirstOrDefault() as EbmlVersion;

        public EbmlReadVersion? ReadVersionElement =>
            (from value in this where value.Value.Id == EbmlIds.EbmlReadVersionId select value.Value).FirstOrDefault() as EbmlReadVersion;

        public EbmlMaxIdLength? MaxIdLengthElement =>
            (from value in this where value.Value.Id == EbmlIds.EbmlMaxIdLengthId select value.Value).FirstOrDefault() as EbmlMaxIdLength;

        public EbmlMaxSizeLength? MaxSizeLengthElement =>
            (from value in this where value.Value.Id == EbmlIds.EbmlMaxSizeLengthId select value.Value).FirstOrDefault() as EbmlMaxSizeLength;

        public DocType? DocTypeElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeId select value.Value).FirstOrDefault() as DocType;

        public DocTypeVersion? DocTypeVersionElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeVersionId select value.Value).FirstOrDefault() as DocTypeVersion;

        public DocTypeReadVersion? DocTypeReadVersionElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeReadVersionId select value.Value).FirstOrDefault() as DocTypeReadVersion;

        public DocTypeExtension? DocTypeExtensionElement =>
            (from value in this where value.Value.Id == EbmlIds.DocTypeExtensionId select value.Value).FirstOrDefault() as DocTypeExtension;

        public ulong Version => VersionElement?.Value ?? 1;
        public ulong ReadVersion => ReadVersionElement?.Value ?? 1;
        public ulong MaxIdLength => MaxIdLengthElement?.Value ?? 4;
        public ulong MaxSizeLength => MaxSizeLengthElement?.Value ?? 8;
        public string DocType => DocTypeElement?.Value ?? string.Empty;
        public ulong DocTypeVersion => DocTypeVersionElement?.Value ?? 1;
        public ulong DocTypeReadVersion => DocTypeReadVersionElement?.Value ?? 1;
        public string DocTypeExtensionName => DocTypeExtensionElement?.DocTypeExtensionName ?? string.Empty;
        public ulong DocTypeExtensionVersion => DocTypeExtensionElement?.DocTypeExtensionVersion ?? 0;
    }

    public class EbmlHeadFactory : EbmlElementFactory
    {
        public override VInt Id => EbmlIds.EbmlHeadId;

        public override EbmlElement Create(VInt dataSize, long position, EbmlElement? parent)
        {
            return new EbmlHead(dataSize, position, parent);
        }
    }
}