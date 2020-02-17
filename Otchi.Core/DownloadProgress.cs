using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MonoTorrent;
using NLog;
using Otchi.Core.EventArgs;

namespace Otchi.Core
{
    public sealed class DownloadProgress : IEnumerable<DownloadRange>, IDisposable
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly SemaphoreSlim _workSemaphore = new SemaphoreSlim(1, 1);

        private List<DownloadRange> DownloadedRanges { get; } = new List<DownloadRange>();

        public Torrent Torrent { get; }
        public int NumberOfPieces => (int)(Torrent.Size / Torrent.PieceLength);

        public DownloadProgress(Torrent torrent, ReadOnlyCollection<int> hashedPieces)
        {
            Debug.Assert(hashedPieces != null, nameof(hashedPieces) + " != null");
            Torrent = torrent ?? throw new ArgumentNullException(nameof(torrent));

            lock (DownloadedRanges)
            {
                for (var i = 0; i < hashedPieces.Count; i++)
                {
                    AddToDownloadRange(i);
                }
            }
        }

        public event EventHandler<DownloadProgressedEventArgs> DownloadProgressed = delegate { };


        public void OnPieceRegistered(PieceRegisteredEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));

            lock (DownloadedRanges)
            {
                if (Torrent is null) return;

                AddToDownloadRange(e.PieceIndex);
            }
        }

        private void AddToDownloadRange(int pieceIndex)
        {
            Logger.Trace($"Adding Piece {pieceIndex}");

            lock (DownloadedRanges)
            {
                for (var i = 0; i < DownloadedRanges.Count; i++)
                {
                    var range = DownloadedRanges[i];

                    // Check if the piece is already registered
                    if (pieceIndex >= range.StartIndex && pieceIndex <= range.EndIndex)
                    {
                        Logger.Debug($"Piece: {pieceIndex} is already in Downloaded range {i}.");
                        return;
                    }

                    // Decrease the StartIndex if the piece index comes right before
                    // Otherwise insert a new Download Range
                    if (pieceIndex < range.StartIndex)
                    {
                        if (pieceIndex == range.StartIndex - 1)
                        {
                            range.StartIndex = pieceIndex;
                            OnDownloadProgressed(range);
                            return;
                        }

                        DownloadedRanges.Insert(i, DownloadRange.FromSize(NumberOfPieces, pieceIndex));
                        OnDownloadProgressed(DownloadedRanges[i + 1]);
                        return;
                    }

                    // Check if the piece is right the next to the end of the current range
                    if (pieceIndex != range.EndIndex + 1) continue;

                    // If the piece would join 2 ranges, merge them
                    if (DownloadedRanges.Count > i + 1 && DownloadedRanges[i + 1].StartIndex == pieceIndex + 1)
                    {
                        range.Merge(DownloadedRanges[i + 1]);
                        DownloadedRanges.RemoveAt(i + 1);
                        OnDownloadProgressed(range);
                        return;
                    }

                    range.EndIndex = pieceIndex;
                    OnDownloadProgressed(range);
                    return;
                }

                DownloadedRanges.Add(DownloadRange.FromSize(NumberOfPieces, pieceIndex));
                OnDownloadProgressed(DownloadedRanges.Last());
            }
        }

        private void OnDownloadProgressed(DownloadRange range)
        {
            Logger.Trace($"Download Progressed: {this}");
            DownloadProgressed(this, new DownloadProgressedEventArgs(range));
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", DownloadedRanges) + "]";
        }


        #region Enumerator

        public IEnumerator<DownloadRange> GetEnumerator()
        {
            return DownloadedRanges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Disposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose) _workSemaphore.Dispose();
        }

        #endregion
    }
}
