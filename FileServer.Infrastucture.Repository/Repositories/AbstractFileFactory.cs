using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public abstract class AbstractFileFactory
    {
        public abstract FileManager GetFileManager(int fileType, int filePathType);
    }
}
