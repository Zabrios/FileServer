using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Model
{
    public class JSONParser 
    {
        public static void CreateJSONFile(string path)
        {
            if (!JSONFileExists(path))
            {
                Console.WriteLine(path);
                StreamWriter file = new StreamWriter(path);
                file = File.CreateText(path);
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
                    filePath = Environment.ExpandEnvironmentVariables(@"%VUELING_HOME%\alumno.json");
                    break;
                default:
                    filePath = ConfigurationManager.AppSettings["Path"];
                    break;
            }
            return filePath;
        }
    }
}
