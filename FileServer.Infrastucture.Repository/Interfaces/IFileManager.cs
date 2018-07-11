using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository.Interfaces
{
    public interface IFileManager
    {
        string FileExtension { get; set; }
        string FilePath { get; set; }
        void CreateFile();
        bool FileExists();
        void WriteToFile(string fileData);
        string RetrieveData();
    }
}
