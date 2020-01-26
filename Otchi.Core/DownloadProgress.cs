using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent;
using MonoTorrent.Client;
using Otchi.Ebml;

namespace Otchi.Core
{
    public class DownloadRange
    {
        private readonly long _numberOfPieces;
        public long StartIndex { get; internal set; }
        public long EndIndex { get; internal set; }

        public double StartRange => StartIndex / (double)_numberOfPieces;
        public double EndRange => EndIndex / (double)_numberOfPieces;
        public double Percentage => (EndIndex - StartIndex + 1) / (double)_numberOfPieces;

        public DownloadRange(long numberOfPieces, long startIndex = 0, long endIndex = 0)
        {
            _numberOfPieces = numberOfPieces;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public static DownloadRange FromSize(long numberOfPieces, long startIndex, long size = 0)
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
            return StartIndex == EndIndex
                ? StartRange.ToString(CultureInfo.CurrentCulture)
                : $" {StartRange} - {EndRange} ";
        }
    }

    public class ObjectInitializedEventArgs : EventArgs
    {
        public ObjectInitializedEventArgs() { }
    }

    public class DownloadProgressedEventArgs : EventArgs
    {
        public DownloadRange ModifiedRange { get; }
        public DownloadProgressedEventArgs(DownloadRange modifiedRange)
        {
            ModifiedRange = modifiedRange;
        }
    }


    public sealed class DownloadProgress : IEnumerable<DownloadRange>, IEnumerator<DownloadRange>
    {
        private EbmlDocument? _document;
        private EbmlDocument? Document
        {
            get => _document;
            set
            {
                _document = value;
                if (_document != null && _torrent != null)
                {
                    ObjectInitialized(this, new ObjectInitializedEventArgs());
                }
            }
        }
        private Torrent? _torrent;

        private Torrent? Torrent
        {
            get => _torrent;
            set
            {
                _torrent = value;
                if (_document != null && _torrent != null)
                {
                    ObjectInitialized(this, new ObjectInitializedEventArgs());
                }
            }
        }

        private long? NumberOfPieces => Torrent?.Size / Torrent?.PieceLength;

        private readonly SortedSet<long> _hashedPieces = new SortedSet<long>();
        private List<DownloadRange> DownloadedRanges { get; } = new List<DownloadRange>();
        private readonly SemaphoreSlim _workSemaphore = new SemaphoreSlim(1, 1);

        public event EventHandler<ObjectInitializedEventArgs> ObjectInitialized = delegate { };
        public event EventHandler<DownloadProgressedEventArgs> DownloadProgressed = delegate { }; 

        public DownloadProgress()
        {
        }

        public DownloadProgress(EbmlDocument document, Torrent torrent)
        {
            Document = document;
            Torrent = torrent;
        }

        public void OnPieceHashed(object sender, PieceHashedEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            if (!e.HashPassed) return;

            lock (DownloadedRanges)
            {
                _hashedPieces.Add(e.PieceIndex);
                AddToDownloadRange(e.PieceIndex);
            }

        }

        private void AddToDownloadRange(long pieceIndex)
        {
            if (NumberOfPieces is null) throw new InvalidOperationException();
            lock (DownloadedRanges)
            {
                for (var i = 0; i < DownloadedRanges.Count; i++)
                {
                    var range = DownloadedRanges[i];
                    if (pieceIndex < range.StartIndex)
                    {
                        if (pieceIndex == range.StartIndex - 1)
                        { 
                            range.StartIndex = pieceIndex;
                                DownloadProgressed(this, new DownloadProgressedEventArgs(range));
                            return;
                        }

                        DownloadedRanges.Insert(i, DownloadRange.FromSize((long)NumberOfPieces, i));
                        DownloadProgressed(this, new DownloadProgressedEventArgs(DownloadedRanges[i]));
                        return;
                    }

                    if (pieceIndex != range.EndIndex + 1) continue;

                    if (DownloadedRanges[i + 1].StartIndex == pieceIndex + 1)
                    {
                        range.Merge(DownloadedRanges[i + 1]);
                        DownloadedRanges.RemoveAt(i+1);
                        DownloadProgressed(this, new DownloadProgressedEventArgs(range));
                    }
                    else
                    {
                        range.EndIndex = pieceIndex;
                        DownloadProgressed(this, new DownloadProgressedEventArgs(range));
                    }

                    return;
                }
                DownloadedRanges.Add(DownloadRange.FromSize((long)NumberOfPieces, pieceIndex));
                DownloadProgressed(this, new DownloadProgressedEventArgs(DownloadedRanges.Last()));
            }
        }

        public void SetDocument(EbmlDocument document)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
            RecalculateRanges();
        }

        public void SetTorrent(Torrent torrent)
        {
            Torrent = torrent ?? throw new ArgumentNullException(nameof(torrent));
            RecalculateRanges();
        }

        private void RecalculateRanges()
        {
            if (Torrent is null || Document is null) return;

            lock (DownloadedRanges)
            {
                foreach (var piece in _hashedPieces)
                {
                    AddToDownloadRange(piece);
                }
            }
        }

        #region Enumerator

        public IEnumerator<DownloadRange> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public DownloadRange Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _workSemaphore.Dispose();
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
                Dispose();
        }

        #endregion

        public override string ToString()
        {
            var s = DownloadedRanges.Aggregate("[", (current, range) => current + range + ", ");

            return s + "]";
        }
    }
}