using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository
{
    public class FileManager : IFileManager
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (typeof(FileManager));

        /// <summary>
        /// Creates the json file if nonexistent.
        /// </summary>
        /// <param name="path">The path.</param>
        public void CreateJSONFileIfNonexistent(string path)
        {
            if (!JSONFileExists(path))
            {
                try
                {
                    var file = File.CreateText(path);
                    file.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool JSONFileExists(string path)
        {
            return File.Exists(path);
        }

        public string PathSelector(int comboIndex)
        {
            string filePath;
            switch (comboIndex)
            {
                case 0:
                    filePath = ConfigurationManager.AppSettings["Path"];
                    break;
                case 1:
                    var environmentPath = Environment.GetEnvironmentVariable("VUELING_HOME");
                    filePath = Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["environmentPathJson"]);
                    //filePath = testPath;
                    //filePath = Path.Combine(environmentPath, ConfigurationManager.AppSettings["fileName"]);
                    break;
                default:
                    filePath = ConfigurationManager.AppSettings["Path"];
                    break;
            }
            return filePath;
        }

        public void WriteToJson(string path, string jsonData)
        {
            try
            {
                File.WriteAllText(path, jsonData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RetrieveJSONData(string path)
        {
            try
            {
                var jsonData = File.ReadAllText(path);
                Console.WriteLine(jsonData);
                return jsonData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
