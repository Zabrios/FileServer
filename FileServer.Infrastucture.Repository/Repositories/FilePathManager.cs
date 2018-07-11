using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class FilePathManager
    {
        public static string FilePath;
        public static string FileExtension;
        

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
                    path = Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["environmentPathJson"] + ConfigurationManager.AppSettings["fileName"]);
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

    }
}
