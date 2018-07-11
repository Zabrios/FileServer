using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class TxtFileManager : Interfaces.IFileManager
    {
        public string FileExtension { get; set; }
        public string FilePath { get; set; }

        public TxtFileManager(int filePathType)
        {
            FileExtension = ConfigurationManager.AppSettings.Get("txtFile");
            FilePath = FilePathManager.PathSelector(filePathType) + FileExtension;
        }

        public void CreateFile()
        {
            if (!FileExists())
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(FilePath, true)) { }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool FileExists()
        {
            return File.Exists(FilePath);
        }

        public string RetrieveData()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile(string fileData)
        {
            throw new NotImplementedException();
        }
    }
}
