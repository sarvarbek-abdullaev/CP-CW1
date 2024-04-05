using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<DownloadItem> DownloadFile(DownloadItem item);

        [OperationContract]
        List<DownloadItem> GetDownloadQueue();
        
        [OperationContract]
        List<DownloadItem> AddNewDownloadItem(DownloadItem item);

    }

    [DataContract]
    public class DownloadItem
    {
        [DataMember]
        public int Id {  get; set; }
        public string TaskId { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string TargetPath { get; set; }

        [DataMember]
        public DownloadItemPriority Priority { get; set; }

        [DataMember]
        public DownloadItemStatus Status { get; set; }

        [DataMember]
        public int Progress { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        public CancellationTokenSource CancellationTokenSource { get; set; }
        public Task DownloadTask { get; set; }
        public long BytesDownloaded { get; set; }

        public DownloadItem(string url, string targetPath, DownloadItemPriority priority)
        {
            TaskId = Guid.NewGuid().ToString();
            Url = url;
            TargetPath = targetPath;
            Priority = priority;
            Status = DownloadItemStatus.Queued;
            Progress = 0;
        }

        public bool ShouldPauseOrCancel()
        {
            return this.Status == DownloadItemStatus.Paused || this.Status == DownloadItemStatus.Cancelled;
        }
    }

    [DataContract]
    public enum DownloadItemStatus
    {
        [EnumMember]
        Queued,

        [EnumMember]
        Paused,

        [EnumMember]
        Cancelled,

        [EnumMember]
        Downloading,

        [EnumMember]
        Error,

        [EnumMember]
        Finished,
    }

    [DataContract]
    public enum DownloadItemPriority
    {
        [EnumMember]
        Low,

        [EnumMember]
        Normal,

        [EnumMember]
        High,
    }


}
