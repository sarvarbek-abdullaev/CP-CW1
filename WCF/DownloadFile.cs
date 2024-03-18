using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    public class DownloadFile
    {
        public int id;
        public string savePath;
        public string url;
        public Priority priority;
        public DateTime dateTime;
        public Status status;
    }

    public enum Priority
    {
        Highest = 5,
        AboveNormal = 4,
        Normal = 3,
        BelowNormal = 2,
        Lowest = 1
    }

    public enum Status
    {
        Downloading,
        Downloaded,
        Canceled,
        Paused,
        Waiting
    }
}
