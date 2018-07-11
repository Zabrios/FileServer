using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class XmlFileManager : Interfaces.IFileManager
    {
        public string FileExtension { get; set; }
        public string FilePath { get; set; }

        public XmlFileManager(int filePathType)
        {
            FileExtension = ConfigurationManager.AppSettings.Get("xmlFile");
            FilePath = FilePathManager.PathSelector(filePathType) + FileExtension;
        }

        public void CreateFile()
        {
            if (!FileExists())
            {
                try
                {
                    using (XmlWriter writer = XmlWriter.Create(FilePath)) { }
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
