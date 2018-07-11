using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Infrastucture.Repository.Interfaces;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class FileManagerFactory : IFileManagerFactory
    {
        public IFileManager GetFileManager(int fileType, int filePathType)
        {
            switch (fileType)
            {
                case 0:
                    return new XmlFileManager(filePathType);
                case 1:
                    return new JsonFileManager(filePathType);
                case 2:
                    return new TxtFileManager(filePathType);
                default:
                    return new JsonFileManager(filePathType);
            } 
        }
    }
}
