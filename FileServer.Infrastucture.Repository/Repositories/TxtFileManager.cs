using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Common.Model;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class TxtFileManager : FileManager
    {
        public override string FileExtension { get; set; }
        public override string FilePath { get; set; }

        public TxtFileManager(int filePathType)
        {
            FileExtension = ConfigurationManager.AppSettings.Get("txtFile");
            FilePath = FilePathManager.PathSelector(filePathType) + FileExtension;
        }

        public override void CreateFile()
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

        public override bool FileExists()
        {
            return File.Exists(FilePath);
        }

        public override string RetrieveData()
        {
            try
            {
                string fileData = File.ReadAllText(FilePath);
                Console.WriteLine(fileData);
                return fileData;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public override void WriteToFile(string fileData)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(FilePath, true))
                {
                    file.WriteLine(fileData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Alumno ProcessAlumnoData(Alumno alumno)
        {
            string data = null;
            try
            {
                WriteToFile(alumno.ToString());
                data = RetrieveData();
                string lastLine = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last();
                string[] items = lastLine.Split(',');
                var alumnoRetorno = new Alumno(items[0], items[1], items[2], items[3]);
                return alumnoRetorno;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

