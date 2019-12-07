using System;

namespace Otchi.Ebml.Types
{
    public static class EbmlDate
    {
        private static readonly DateTime Epoch = new DateTime(2001, 1, 1, 0, 0, 0, 0);

        public static DateTime FromNanoSeconds(long nanoSeconds)
        {
            return Epoch.AddMilliseconds(nanoSeconds * 0.000001);
        }
    }
}
