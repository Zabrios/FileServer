using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Model
{
    public class JSONParser
    {
        public void CreateJSONFile(string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            if (!JSONFileExists(path))
            {
                file = File.CreateText(path);
            }
        }

        public bool JSONFileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
