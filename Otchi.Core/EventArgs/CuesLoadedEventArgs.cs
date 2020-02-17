using Otchi.Matroska.Tags;

namespace Otchi.Core.EventArgs
{
    public class CuesLoadedEventArgs
    {
        public Cues Cues { get; }

        public CuesLoadedEventArgs(Cues cues)
        {
            Cues = cues;
        }
    }
}