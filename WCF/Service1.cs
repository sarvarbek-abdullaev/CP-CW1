using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetDownloadFileData(DownloadFile downloadFile)
        {
            return "Hello World";
        }

        public void DownloadFile(string fileUrl, string savePath)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(fileUrl, savePath);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error downloading file: {ex.Message}");
            }
        }
    }
}
