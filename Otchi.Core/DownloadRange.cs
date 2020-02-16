using System;
using System.Globalization;
using NLog;

namespace Otchi.Core
{
    public class DownloadRange
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly int _numberOfPieces;
        private int _startIndex;
        private int _endIndex;

        public int StartIndex
        {
            get => _startIndex;
            internal set
            {
                if (value > EndIndex)
                {
                    Logger.Error($"StartIndex: {value} got assigned to be behind EndIndex {EndIndex}");
                }
                _startIndex = value;
            }
        }

        public int EndIndex
        {
            get => _endIndex;
            internal set
            {
                if (value < StartIndex)
                {
                    Logger.Error($"EndIndex: {value} got assigned to be before StartIndex {StartIndex}");
                }
                _endIndex = value;
            }
        }

        public double StartRange => StartIndex / (double)_numberOfPieces;
        public double EndRange => EndIndex / (double)_numberOfPieces;
        public double Percentage => Count / (double)_numberOfPieces;
        public int Count => EndIndex - StartIndex + 1;

        public DownloadRange(int numberOfPieces, int startIndex = 0, int endIndex = 0)
        {
            _numberOfPieces = numberOfPieces;
            EndIndex = endIndex;
            StartIndex = startIndex;
        }

        public static DownloadRange FromSize(int numberOfPieces, int startIndex, int size = 0)
        {
            return new DownloadRange(numberOfPieces, startIndex, startIndex + size);
        }

        public DownloadRange Merge(DownloadRange other)
        {
            return Merge(this, other);
        }

        public static DownloadRange Merge(DownloadRange first, DownloadRange second)
        {
            if (first is null) throw new ArgumentNullException(nameof(first));
            if (second is null) throw new ArgumentNullException(nameof(second));
            first.StartIndex = Math.Min(first.StartIndex, second.StartIndex);
            first.EndIndex = Math.Max(first.EndIndex, second.EndIndex);
            return first;
        }

        public override string ToString()
        {
            return $"{StartIndex} - {EndIndex}";
        }
    }
}