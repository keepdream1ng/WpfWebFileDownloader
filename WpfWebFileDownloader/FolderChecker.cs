using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWebFileDownloader
{
    public static class FolderChecker
    {
        public static bool IsDirectoryWritable(string directoryToCheckPath)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        directoryToCheckPath, 
                        Guid.NewGuid().ToString()
                    ), 
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
