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
            try
            {
                string fileData = File.ReadAllText(FilePath);
                Console.WriteLine(fileData);
                return fileData;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void WriteToFile(string fileData)
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

        public Alumno ProcessAlumnoData(Alumno alumno)
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

            //foreach (var myString in data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

