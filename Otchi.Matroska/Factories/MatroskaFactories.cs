using System;
using System.Collections.Generic;
using System.Linq;
using Otchi.Ebml.Elements;
using Otchi.Ebml.Factories;
using MatroskaIds = Otchi.Matroska.Tags.MatroskaIds;
using FactoriesDict = System.Collections.Generic.Dictionary<long, Otchi.Ebml.Factories.EbmlElementFactory>;

namespace Otchi.Matroska.Factories
{
    public static class MatroskaFactories
    {
        private static Dictionary<long, EbmlElementFactory> Factories
        {
            get
            {
                var assembly = typeof(MatroskaFactories).Assembly;
                var factories =
                    (from type in assembly.GetTypes()
                        where type.IsSubclassOf(typeof(EbmlElement)) && !type.IsAbstract
                        let factoryType = assembly.GetType($"{type.FullName}Factory")
                        let factory = (EbmlElementFactory)Activator.CreateInstance(factoryType)
                        select new { factory.Id, Factory = factory }
                    ).ToDictionary(element => element.Id.Size, element => element.Factory);
                return factories;
            }
        }

        public static FactoriesDict AllMatroskaFactories { get; } = Factories;

        private static readonly List<long> MatroskaSegmentIds = new List<long>
        {
            MatroskaIds.SegmentId.Size
        };

        public static FactoriesDict MatroskaSegmentFactories { get; } =
            FactoriesFromIds(MatroskaSegmentIds);

        private static readonly List<long> MetaSeekInformationIds = new List<long>
        {
            MatroskaIds.SeekHeadId.Size, MatroskaIds.SeekId.Size, MatroskaIds.SeekIDId.Size, MatroskaIds.SeekPositionId.Size
        };

        public static FactoriesDict MetaSeekInformationFactories { get; } =
            FactoriesFromIds(MetaSeekInformationIds);

        private static readonly List<long> SegmentInformationIds = new List<long>
        {
            MatroskaIds.InfoId.Size, MatroskaIds.SegmentUIDId.Size, MatroskaIds.SegmentFilenameId.Size, MatroskaIds.PrevUIDId.Size,
            MatroskaIds.PrevFilenameId.Size, MatroskaIds.NextUIDId.Size, MatroskaIds.NextFilenameId.Size, MatroskaIds.SegmentFamilyId.Size,
            MatroskaIds.ChapterTranslateId.Size, MatroskaIds.ChapterTranslateEditionUIDId.Size, MatroskaIds.ChapterTranslateCodecId.Size, 
            MatroskaIds.TimestampScaleId.Size, MatroskaIds.DurationId.Size, MatroskaIds.DateUTCId.Size,
            MatroskaIds.TitleId.Size, MatroskaIds.MuxingAppId.Size, MatroskaIds.WritingAppId.Size
        };

        public static FactoriesDict SegmentInformationFactories { get; } =
            FactoriesFromIds(SegmentInformationIds);

        private static readonly List<long> ClusterInformationIds = new List<long>
        {
            MatroskaIds.ClusterId.Size, MatroskaIds.TimestampId.Size, MatroskaIds.SilentTracksId.Size, MatroskaIds.SilentTrackNumberId.Size,
            MatroskaIds.PositionId.Size, MatroskaIds.PrevSizeId.Size, MatroskaIds.SimpleBlockId.Size, MatroskaIds.BlockGroupId.Size,
            MatroskaIds.BlockId.Size, MatroskaIds.BlockVirtualId.Size, MatroskaIds.BlockAdditionsId.Size, MatroskaIds.BlockMoreId.Size,
            MatroskaIds.BlockAddIDId.Size, MatroskaIds.BlockAdditionalId.Size, MatroskaIds.BlockDurationId.Size, MatroskaIds.ReferencePriorityId.Size,
            MatroskaIds.ReferenceBlockId.Size, MatroskaIds.ReferenceVirtualId.Size, MatroskaIds.CodecStateId.Size, MatroskaIds.DiscardPaddingId.Size,
            MatroskaIds.SlicesId.Size, MatroskaIds.TimeSliceId.Size, MatroskaIds.LaceNumberId.Size, MatroskaIds.FrameNumberId.Size,
            MatroskaIds.BlockAdditionIDId.Size, MatroskaIds.DelayId.Size, MatroskaIds.SliceDurationId.Size, MatroskaIds.ReferenceFrameId.Size,
            MatroskaIds.ReferenceOffsetId.Size, MatroskaIds.ReferenceTimestampId.Size, MatroskaIds.EncryptedBlockId.Size
        };

        public static FactoriesDict ClusterInformationFactories { get; } =
            FactoriesFromIds(ClusterInformationIds);

        private static readonly List<long> TrackIds = new List<long>
        {
            MatroskaIds.TracksId.Size, MatroskaIds.TrackEntryId.Size, MatroskaIds.TrackNumberId.Size, MatroskaIds.TrackUIDId.Size,
            MatroskaIds.TrackTypeId.Size, MatroskaIds.FlagEnabledId.Size, MatroskaIds.FlagDefaultId.Size, MatroskaIds.FlagForcedId.Size,
            MatroskaIds.FlagLacingId.Size, MatroskaIds.MinCacheId.Size, MatroskaIds.MaxCacheId.Size, MatroskaIds.DefaultDurationId.Size,
            MatroskaIds.DefaultDecodedFieldDurationId.Size, MatroskaIds.TrackTimestampScaleId.Size, MatroskaIds.TrackOffsetId.Size,
            MatroskaIds.MaxBlockAdditionIDId.Size, MatroskaIds.NameId.Size, MatroskaIds.LanguageId.Size, MatroskaIds.LanguageIETFId.Size,
            MatroskaIds.CodecIDId.Size, MatroskaIds.CodecPrivateId.Size, MatroskaIds.CodecNameId.Size, MatroskaIds.AttachmentLinkId.Size,
            MatroskaIds.CodecSettingsId.Size, MatroskaIds.CodecInfoURLId.Size, MatroskaIds.CodecDownloadURLId.Size,
            MatroskaIds.CodecDecodeAllId.Size, MatroskaIds.TrackOverlayId.Size, MatroskaIds.CodecDelayId.Size, MatroskaIds.SeekPreRollId.Size,
            MatroskaIds.TrackTranslateId.Size, MatroskaIds.TrackTranslateEditionUIDId.Size, MatroskaIds.TrackTranslateCodecId.Size,
            MatroskaIds.TrackTranslateTrackIDId.Size, MatroskaIds.VideoId.Size, MatroskaIds.FlagInterlacedId.Size, MatroskaIds.FieldOrderId.Size,
            MatroskaIds.StereoModeId.Size, MatroskaIds.AlphaModeId.Size, MatroskaIds.OldStereoModeId.Size, MatroskaIds.PixelWidthId.Size,
            MatroskaIds.PixelHeightId.Size, MatroskaIds.PixelCropBottomId.Size, MatroskaIds.PixelCropTopId.Size, MatroskaIds.PixelCropLeftId.Size,
            MatroskaIds.PixelCropRightId.Size, MatroskaIds.DisplayWidthId.Size, MatroskaIds.DisplayHeightId.Size, MatroskaIds.DisplayUnitId.Size,
            MatroskaIds.AspectRatioTypeId.Size, MatroskaIds.ColourSpaceId.Size, MatroskaIds.GammaValueId.Size, MatroskaIds.FrameRateId.Size,
            MatroskaIds.ColourId.Size, MatroskaIds.MatrixCoefficientsId.Size, MatroskaIds.BitsPerChannelId.Size, MatroskaIds.ChromaSubsamplingHorzId.Size,
            MatroskaIds.ChromaSubsamplingVertId.Size, MatroskaIds.CbSubsamplingHorzId.Size, MatroskaIds.CbSubsamplingVertId.Size,
            MatroskaIds.ChromaSitingHorzId.Size, MatroskaIds.ChromaSitingVertId.Size, MatroskaIds.RangeId.Size, MatroskaIds.TransferCharacteristicsId.Size,
            MatroskaIds.PrimariesId.Size, MatroskaIds.MaxCLLId.Size, MatroskaIds.MaxFALLId.Size, MatroskaIds.MasteringMetadataId.Size,
            MatroskaIds.PrimaryRChromaticityXId.Size, MatroskaIds.PrimaryRChromaticityYId.Size, MatroskaIds.PrimaryGChromaticityXId.Size,
            MatroskaIds.PrimaryGChromaticityYId.Size, MatroskaIds.PrimaryBChromaticityXId.Size, MatroskaIds.PrimaryBChromaticityYId.Size,
            MatroskaIds.WhitePointChromaticityXId.Size, MatroskaIds.WhitePointChromaticityYId.Size, MatroskaIds.LuminanceMaxId.Size,
            MatroskaIds.LuminanceMinId.Size, MatroskaIds.ProjectionId.Size, MatroskaIds.ProjectionTypeId.Size, MatroskaIds.ProjectionPrivateId.Size,
            MatroskaIds.ProjectionPoseYawId.Size, MatroskaIds.ProjectionPosePitchId.Size, MatroskaIds.ProjectionPoseRollId.Size,
            MatroskaIds.AudioId.Size, MatroskaIds.SamplingFrequencyId.Size, MatroskaIds.OutputSamplingFrequencyId.Size,
            MatroskaIds.ChannelsId.Size, MatroskaIds.ChannelPositionsId.Size, MatroskaIds.BitDepthId.Size, MatroskaIds.TrackOperationId.Size,
            MatroskaIds.TrackCombinePlanesId.Size, MatroskaIds.TrackPlaneId.Size, MatroskaIds.TrackPlaneUIDId.Size, MatroskaIds.TrackPlaneTypeId.Size,
            MatroskaIds.TrackJoinBlocksId.Size, MatroskaIds.TrackJoinUIDId.Size, MatroskaIds.TrickTrackUIDId.Size, MatroskaIds.TrickTrackSegmentUIDId.Size,
            MatroskaIds.TrickTrackFlagId.Size, MatroskaIds.TrickMasterTrackUIDId.Size, MatroskaIds.TrickMasterTrackSegmentUIDId.Size,
            MatroskaIds.ContentEncodingsId.Size, MatroskaIds.ContentEncodingId.Size, MatroskaIds.ContentEncodingOrderId.Size,
            MatroskaIds.ContentEncodingScopeId.Size, MatroskaIds.ContentEncodingTypeId.Size, MatroskaIds.ContentCompressionId.Size,
            MatroskaIds.ContentCompAlgoId.Size, MatroskaIds.ContentCompSettingsId.Size, MatroskaIds.ContentEncryptionId.Size,
            MatroskaIds.ContentEncAlgoId.Size, MatroskaIds.ContentEncKeyIDId.Size, MatroskaIds.ContentEncAESSettingsId.Size,
            MatroskaIds.AESSettingsCipherModeId.Size, MatroskaIds.ContentSignatureId.Size, MatroskaIds.ContentSigAlgoId.Size,
            MatroskaIds.ContentSigHashAlgoId.Size
        };

        public static FactoriesDict TrackFactories { get; } = FactoriesFromIds(TrackIds);

        private static readonly List<long> CueingDataIds = new List<long>
        {
            MatroskaIds.CuesId.Size, MatroskaIds.CuePointId.Size, MatroskaIds.CueTimeId.Size, MatroskaIds.CueTrackPositionsId.Size,
            MatroskaIds.CueClusterPositionId.Size, MatroskaIds.CueRelativePositionId.Size, MatroskaIds.CueDurationId.Size,
            MatroskaIds.CueBlockNumberId.Size, MatroskaIds.CueCodecStateId.Size, MatroskaIds.CueReferenceId.Size,
            MatroskaIds.CueRefTimeId.Size, MatroskaIds.CueRefClusterId.Size, MatroskaIds.CueRefNumberId.Size, MatroskaIds.CueRefCodecStateId.Size
        };

        public static FactoriesDict CueingDataFactories { get; } = FactoriesFromIds(CueingDataIds);

        private static readonly List<long> AttachmentIds = new List<long>
        {
            MatroskaIds.AttachmentsId.Size, MatroskaIds.AttachedFileId.Size, MatroskaIds.FileDescriptionId.Size,
            MatroskaIds.FileNameId.Size, MatroskaIds.FileMimeTypeId.Size, MatroskaIds.FileDataId.Size, MatroskaIds.FileUIDId.Size,
            MatroskaIds.FileReferralId.Size, MatroskaIds.FileUsedStartTimeId.Size, MatroskaIds.FileUsedEndTimeId.Size
        };

        public static FactoriesDict AttachmentFactories { get; } = FactoriesFromIds(AttachmentIds);

        private static readonly List<long> ChapterIds = new List<long>
        {
            MatroskaIds.ChaptersId.Size, MatroskaIds.EditionEntryId.Size, MatroskaIds.EditionUIDId.Size, MatroskaIds.EditionFlagHiddenId.Size,
            MatroskaIds.EditionFlagDefaultId.Size, MatroskaIds.EditionFlagOrderedId.Size, MatroskaIds.ChapterAtomId.Size,
            MatroskaIds.ChapterUIDId.Size, MatroskaIds.ChapterStringUIDId.Size, MatroskaIds.ChapterTimeStartId.Size,
            MatroskaIds.ChapterTimeEndId.Size, MatroskaIds.ChapterFlagHiddenId.Size, MatroskaIds.ChapterFlagEnabledId.Size,
            MatroskaIds.ChapterSegmentUIDId.Size, MatroskaIds.ChapterSegmentEditionUIDId.Size, MatroskaIds.ChapterPhysicalEquivId.Size,
            MatroskaIds.ChapterTrackId.Size, MatroskaIds.ChapterDisplayId.Size, MatroskaIds.ChapStringId.Size, MatroskaIds.ChapLanguageId.Size,
            MatroskaIds.ChapLanguageIETFId.Size, MatroskaIds.ChapCountryId.Size, MatroskaIds.ChapProcessId.Size, MatroskaIds.ChapProcessCodecIDId.Size,
            MatroskaIds.ChapProcessPrivateId.Size, MatroskaIds.ChapProcessCommandId.Size, MatroskaIds.ChapProcessTimeId.Size,
            MatroskaIds.ChapProcessDataId.Size
        };

        public static FactoriesDict ChapterFactories { get; } = FactoriesFromIds(ChapterIds);

        private static readonly List<long> TaggingIds = new List<long>
        {
            MatroskaIds.TagsId.Size, MatroskaIds.TagId.Size, MatroskaIds.TargetsId.Size, MatroskaIds.TargetTypeValueId.Size,
            MatroskaIds.TargetTypeId.Size, MatroskaIds.TagTrackUIDId.Size, MatroskaIds.TagEditionUIDId.Size,
            MatroskaIds.TagChapterUIDId.Size, MatroskaIds.TagAttachmentUIDId.Size, MatroskaIds.SimpleTagId.Size,
            MatroskaIds.TagNameId.Size, MatroskaIds.TagLanguageId.Size, MatroskaIds.TagLanguageIETFId.Size,
            MatroskaIds.TagDefaultId.Size, MatroskaIds.TagStringId.Size, MatroskaIds.TagBinaryId.Size
        };

        public static FactoriesDict TaggingFactories { get; } = FactoriesFromIds(TaggingIds);

        private static FactoriesDict FactoriesFromIds(IEnumerable<long> factoryIds)
        {
            return (from factory in Factories
                    where factoryIds.Contains(factory.Key)
                    select factory)
                .ToDictionary(element => element.Key, element => element.Value);
        }
    }
}