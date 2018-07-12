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
        public static string FileExtension;

        //public static fil

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
                    using (StreamWriter file = new StreamWriter(FilePath, true)){}
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

        public static void GetFilePath(int cboInd1, int cboInd2)
        {
            FileExtensionSelector(cboInd2);
            FilePath = PathSelector(cboInd1) + FileExtension;
        }

        public static string PathSelector(int comboIndex)
        {
            string path;
            switch (comboIndex)
            {
                case 0:
                    path = ConfigurationManager.AppSettings["Path"] + ConfigurationManager.AppSettings["fileName"];
                    break;
                case 1:
                    path = Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["environmentPath"] + ConfigurationManager.AppSettings["fileName"]);
                    break;
                default:
                    path = ConfigurationManager.AppSettings["Path"] + ConfigurationManager.AppSettings["fileName"];
                    break;
            }
            return path;
        }

        public static void FileExtensionSelector(int comboIndex)
        {
            switch (comboIndex)
            {
                case 0:
                    FileExtension = ConfigurationManager.AppSettings.Get("xmlFile");
                    break;
                case 1:
                    FileExtension = ConfigurationManager.AppSettings.Get("jsonFile");
                    break;
                case 2:
                    FileExtension = ConfigurationManager.AppSettings.Get("txtFile");
                    break;
                default:
                    FileExtension = ConfigurationManager.AppSettings.Get("jsonFile");
                    break;
            }
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
