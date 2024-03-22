using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    public class ProgressChangedEventArgs : EventArgs
    {
        public int BytesDownloaded { get; }
        public int TotalBytes { get; }
        public TimeSpan TimeLeft { get; }

        public ProgressChangedEventArgs(int bytesDownloaded, int totalBytes, TimeSpan timeLeft)
        {
            BytesDownloaded = bytesDownloaded;
            TotalBytes = totalBytes;
            TimeLeft = timeLeft;
        }
    }
}
