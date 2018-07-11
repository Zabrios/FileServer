using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository.Interfaces
{
    public interface IFileManagerFactory
    {
        IFileManager GetFileManager(int fileType, int filePathType);
    }
}
