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
        public HttpDownloader client { get; private set; }

        public void DownloadFile()
        {
            if (client != null)
            {
                client.StopReset();
            }
            client = new HttpDownloader(DownloadLink, Path.Combine(SavePath, FileName));
            client.Start();
            return;
        }
    }
}
