namespace Otchi.Core.EventArgs
{
    public class DownloadProgressedEventArgs : System.EventArgs
    {
        public DownloadRange ModifiedRange { get; }
        public DownloadProgressedEventArgs(DownloadRange modifiedRange)
        {
            ModifiedRange = modifiedRange;
        }
    }
}