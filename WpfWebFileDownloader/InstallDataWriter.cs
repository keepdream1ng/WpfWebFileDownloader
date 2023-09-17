using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWebFileDownloader
{
    public static class InstallDataWriter
    {
        public static void Write(string path) {
            var installData = new { timestamp = DateTime.Now };
            string json = JsonConvert.SerializeObject(installData);
            //write string to file
            System.IO.File.WriteAllText(Path.Combine(path, "installdata.json"), json); 
        }
    }
}
