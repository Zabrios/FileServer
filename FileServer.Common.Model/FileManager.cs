using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Model
{
    public class FileManager 
    {
        public static void CreateJSONFileIfNonexistent(string path)
        {
            if (!JSONFileExists(path))
            {
                Console.WriteLine(path);
                //StreamWriter file = new StreamWriter(path);
                var file2 = File.CreateText(path);
                file2.Close();
            }
        }

        public static bool JSONFileExists(string path)
        {
            return File.Exists(path);
        }

        public static string PathSelector (int comboIndex)
        {
            string filePath;
            switch (comboIndex)
            {
                case 0:
                    filePath = ConfigurationManager.AppSettings["Path"];
                    break;
                case 1:
                    var environmentPath = Environment.GetEnvironmentVariable("VUELING_HOME");
                    filePath = Path.Combine(environmentPath, ConfigurationManager.AppSettings["fileName"]);
                    //filePath = Environment.ExpandEnvironmentVariables(@"%VUELING_HOME%\alumno.json");
                    break;
                default:
                    filePath = ConfigurationManager.AppSettings["Path"];
                    break;
            }
            return filePath;
        }
    }
}
