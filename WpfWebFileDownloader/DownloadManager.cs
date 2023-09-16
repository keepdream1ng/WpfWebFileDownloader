using AltoHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfWebFileDownloader
{
    public class DownloadManager
    {
        public string DownloadLink { get; set; }
        public string FileName { get { return Path.GetFileName(DownloadLink); } }
        public string SavePath { get; set; }

        private string _tempFilePath;
        public HttpDownloader client { get; private set; }

        public void DownloadFile()
        {
            if (client != null)
            {
                client.StopReset();
            }
            _tempFilePath = Path.Combine(SavePath, Guid.NewGuid().ToString());
            client = new HttpDownloader(DownloadLink, _tempFilePath);
            client.Start();
            return;
        }

        public void GiveFileFinalName()
        {
            string fullFinalName = Path.Combine(SavePath, FileName);
            if (File.Exists(fullFinalName))
            {
                File.Delete(fullFinalName);
            }
            File.Move(_tempFilePath, fullFinalName);
        }
    }
}
