using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Common.Model;
using Newtonsoft.Json;

namespace FileServer.Infrastucture.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        public Alumno Add(Alumno alumno, string path)
        {
            FileManager fileManager = new FileManager();
            List<Alumno> jsonNodes = null;

            fileManager.CreateJSONFileIfNonexistent(path);
            var data = fileManager.RetrieveJSONData(path);

            jsonNodes = JsonConvert.DeserializeObject<List<Alumno>>(data);
            if (jsonNodes == null)
            {
                jsonNodes = new List<Alumno>();
            }
            jsonNodes.Add(alumno);

            var resultJSONList = JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
            fileManager.WriteToJson(path, resultJSONList);
            return JsonConvert.DeserializeObject<List<Alumno>>(fileManager.RetrieveJSONData(path)).Last();
        }
    }
}
