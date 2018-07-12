using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Common.Model;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public abstract class FileManager
    {
        public virtual string FileExtension { get; set; }
        public virtual string FilePath { get; set; }

        public virtual void CreateFile()
        {
        }

        public virtual bool FileExists()
        {
            return true;
        }

        public virtual Alumno ProcessAlumnoData(Alumno alumno)
        {
            return alumno;
        }

        public virtual string RetrieveData()
        {
            return null;
        }

        public virtual void WriteToFile(string fileData)
        {
        }
    }
}
