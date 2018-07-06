using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository
{
    public class FileManager 
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string FilePath;

        /// <summary>
        /// Creates the json file if nonexistent.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void CreateJSONFileIfNonexistent()
        {
            if (!JSONFileExists())
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(FilePath, true))
                    {
                        file.Dispose();
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw ex;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
                catch (DirectoryNotFoundException ex)
                {
                    throw ex;
                }
                catch (IOException ex)
                {
                    throw ex;
                }
                catch (System.Security.SecurityException ex)
                {
                    throw ex;
                }
            }
        }

        public static bool JSONFileExists()
        {
            return File.Exists(FilePath);
        }

        public static string PathSelector(int comboIndex)
        {
            //string filePath;
            switch (comboIndex)
            {
                case 0:
                    //filePath = Path.Combine(environmentPath, ConfigurationManager.AppSettings["fileName"]);
                    FilePath = ConfigurationManager.AppSettings["Path"] + ConfigurationManager.AppSettings["fileName"];
                    break;
                case 1:
                    //var environmentPath = Environment.GetEnvironmentVariable("VUELING_HOME");
                    FilePath = Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["environmentPathJson"]);
                    break;
                default:
                    FilePath = ConfigurationManager.AppSettings["Path"] + ConfigurationManager.AppSettings["fileName"];
                    //filePath = ConfigurationManager.AppSettings["Path"];
                    break;
            }
            return FilePath;
        }

        public static void WriteToJson(string jsonData)
        {
            try
            {
                File.WriteAllText(FilePath, jsonData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string RetrieveJSONData()
        {
            try
            {
                var jsonData = File.ReadAllText(FilePath);
                return jsonData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
