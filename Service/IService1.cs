using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string EnqueueDownload(string url, string targetPath, DTaskPriority priority);

        [OperationContract]
        List<DTask> GetDownloadQueue();
        
        [OperationContract]
        void StartDownloadOne(DTask dTask);

        [OperationContract]
        List<DTask> GetDownloadedList();

        [OperationContract]
        bool PauseDownload(string taskId);

        [OperationContract]
        bool ResumeDownload(string taskId);

        [OperationContract]
        bool CancelDownload(string taskId);
    }

    [DataContract]
    public class DTask
    {
        [DataMember]
        public string TaskId { get; set; }

        [DataMember]
        public string Url { get; set; }        
        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string TargetPath { get; set; }

        [DataMember]
        public DTaskPriority Priority { get; set; }

        [DataMember]
        public DTaskStatus Status { get; set; }

        [DataMember]
        public double Progress { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string timeLeftText { get; set; }

        public CancellationTokenSource CancellationTokenSource { get; set; }
        public Task DownloadTask { get; set; }
        public long TotalBytes { get; set; }
        public long BytesDownloaded { get; set; }
        public double TimeLeft { get; set; }


        public DTask(string url, string targetPath, DTaskPriority priority)
        {
            TaskId = Guid.NewGuid().ToString();
            Url = url;
            TargetPath = targetPath;
            Priority = priority;
            Status = DTaskStatus.Queued;
            Progress = 0;
        }

        public bool ShouldPauseOrCancel()
        {
            return this.Status == DTaskStatus.Paused || this.Status == DTaskStatus.Cancelled;
        }
    }

    [DataContract]
    public enum DTaskStatus
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
    public enum DTaskPriority
    {
        [EnumMember]
        Low,

        [EnumMember]
        Normal,

        [EnumMember]
        High,
    }

}
