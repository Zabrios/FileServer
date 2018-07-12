using FileServer.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository.Repositories
{
    public class JsonFileManager : FileManager
    {
        public override string FileExtension { get; set; }
        public override string FilePath { get; set; }

        public JsonFileManager(int filePathType)
        {
            FileExtension = ConfigurationManager.AppSettings.Get("jsonFile");
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
                catch(Exception ex)
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
                var jsonData = File.ReadAllText(FilePath);
                return jsonData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void WriteToFile(string fileData)
        {
            try
            {
                File.WriteAllText(FilePath, fileData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Alumno ProcessAlumnoData(Alumno alumno)
        {
            List<Alumno> jsonNodes = null;
            try
            {
                CreateFile();
                var data = RetrieveData();
                jsonNodes = JsonConvert.DeserializeObject<List<Alumno>>(data);
                if (jsonNodes == null)
                {
                    jsonNodes = new List<Alumno>();
                }
                jsonNodes.Add(alumno);

                var resultJSONList = JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
                WriteToFile(resultJSONList);
                return JsonConvert.DeserializeObject<List<Alumno>>(RetrieveData()).Last();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
