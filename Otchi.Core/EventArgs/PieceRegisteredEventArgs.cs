namespace Otchi.Core.EventArgs
{
    public sealed class PieceRegisteredEventArgs: System.EventArgs
    {
        public int PieceIndex { get; }

        public PieceRegisteredEventArgs(int pieceIndex)
        {
            PieceIndex = pieceIndex;
        }

    }
}
