using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MonoTorrent;
using MonoTorrent.Client;
using Otchi.Ebml;

namespace Otchi.Core
{
    public class DownloadProgress
    {
        private EbmlDocument? _document;
        private Torrent? _torrent;

        private readonly SortedSet<long> _hashedPieces = new SortedSet<long>();
        public List<Range> DownloadedRanges { get; private set; } = new List<Range>();
        private readonly SemaphoreSlim _workSemaphore = new SemaphoreSlim(1,1);

        public DownloadProgress() { }

        public DownloadProgress(EbmlDocument document, Torrent torrent)
        {
            _document = document;
            _torrent = torrent;
        }

        public async void OnPieceHashed(object sender, PieceHashedEventArgs e)
        {
            if (!e.HashPassed) return;
            await _workSemaphore.WaitAsync();
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
            await RecalculateRanges();
        }

        public async Task SetTorrent(Torrent torrent)
        {
            _torrent = torrent ?? throw new ArgumentNullException(nameof(torrent));
            await RecalculateRanges();
        }

        private async Task RecalculateRanges()
        {
            if (_torrent is null || _document is null) return;
            await _workSemaphore.WaitAsync();

            try
            {
                DownloadedRanges = new List<Range>();
                foreach (var piece in _hashedPieces)
                {
                    foreach (var range in DownloadedRanges)
                    {
                        if (range.Start)
                    }
                }
            }
            finally
            {
                _workSemaphore.Release(1);
            }
        }
    }
}