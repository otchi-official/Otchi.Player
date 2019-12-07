using Otchi.BitOperations;

namespace Otchi.Ebml.Types
{
    public class VInt
    {
        public int VintWidth { get; }
        public int MarkerPosition { get; }
        public long DataSize { get; }
        public long Size { get; }
        public int ByteSize => (VintWidth + 1);

        public VInt(int vintWidth, long dataSize)
        {
            VintWidth = vintWidth;
            DataSize = dataSize;

            const int byteSize = 8;
            MarkerPosition = (byteSize - 1) * (vintWidth + 1);

            var value = DataSize;
            value ^= 1 << MarkerPosition;
            Size = value;
        }

        public static VInt FromMarkerPosition(int markerPosition, long data)
        {
            const int byteSize = 8;
            var width = markerPosition / (byteSize - 1) - 1;
            return new VInt(width, data);
        }

        public static VInt FromValue(long value)
        {
            var mostSignificantBit = value.GetMostSignificantBit();
            // disable mbr bit
            value ^= 1L << mostSignificantBit;
            return FromMarkerPosition(mostSignificantBit, value);
        }

        public static VInt ToVInt(long instance)
        {
            return FromValue(instance);
        }

        public static implicit operator VInt(long instance)
        {
            return ToVInt(instance);
        }
    }
}