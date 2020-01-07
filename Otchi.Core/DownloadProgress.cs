using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent;
using MonoTorrent.Client;
using Otchi.Ebml;

namespace Otchi.Core
{

    public class DownloadRange
    {
        private const int Decimals = 2;

        private double _startRange;
        public double StartRange
        {
            get => _startRange;
            set => _startRange = Math.Round(value, Decimals);
        }

        private double _endRange;
        public double EndRange
        {
            get => _endRange;
            set => _endRange = Math.Round(value, 2);
        }


        public DownloadRange(double startRange, double endRange)
        {
            StartRange = startRange;
            EndRange = endRange;
        }

        public DownloadRange Merge(DownloadRange other)
        {
            return Merge(this, other);
        }

        public static DownloadRange Merge(DownloadRange first, DownloadRange second)
        {
            if (first is null) throw new ArgumentNullException(nameof(first));
            if (second is null) throw new ArgumentNullException(nameof(second));
            return new DownloadRange(
                Math.Min(first.StartRange, second.StartRange),
                Math.Max(first.EndRange, second.EndRange));
        }
    }


    public sealed class DownloadProgress: IEnumerable<DownloadRange>, IEnumerator<DownloadRange>
    {
        private EbmlDocument? _document;
        private Torrent? _torrent;

        private readonly SortedSet<long> _hashedPieces = new SortedSet<long>();
        private List<Range> DownloadedRanges { get; } = new List<Range>();
        private readonly SemaphoreSlim _workSemaphore = new SemaphoreSlim(1, 1);

        public DownloadProgress() { }

        public DownloadProgress(EbmlDocument document, Torrent torrent)
        {
            _document = document;
            _torrent = torrent;
        }

        public async void OnPieceHashed(object sender, PieceHashedEventArgs e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            if (!e.HashPassed) return;
            await _workSemaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                _hashedPieces.Add(e.PieceIndex);

            }
            finally
            {
                _workSemaphore.Release(1);
            }
        }

        public async Task SetDocument(EbmlDocument document)
        {
            _document = document ?? throw new ArgumentNullException(nameof(document));
            await RecalculateRanges().ConfigureAwait(false);
        }

        public async Task SetTorrent(Torrent torrent)
        {
            _torrent = torrent ?? throw new ArgumentNullException(nameof(torrent));
            await RecalculateRanges().ConfigureAwait(false);
        }

        private async Task RecalculateRanges()
        {
            if (_torrent is null || _document is null) return;
            await _workSemaphore.WaitAsync().ConfigureAwait(false);

            try
            {
                var numberOfPieces = (int)(_torrent.Size + _torrent.PieceLength - 1) / _torrent.PieceLength;
                foreach (var pieceIndex in _hashedPieces)
                {

                }
                /*DownloadedRanges = new List<Range>();
                foreach (var piece in _hashedPieces)
                {
                    foreach (var range in DownloadedRanges)
                    {
                        if (range.Start)
                    }
                }*/
            }
            finally
            {
                _workSemaphore.Release(1);
            }
        }

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
    }
}