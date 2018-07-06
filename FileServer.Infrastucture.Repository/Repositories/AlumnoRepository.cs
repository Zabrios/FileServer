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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (typeof(AlumnoRepository));
        public AlumnoRepository()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public Alumno Add(Alumno alumno, string path)
        {
            FileManager fileManager = new FileManager();
            List<Alumno> jsonNodes = null;

            log.Debug("alumno " + alumno.ToString());
            log.Debug("path = " + path);

            fileManager.CreateJSONFileIfNonexistent(path);
            var data = fileManager.RetrieveJSONData(path);
            log.Debug("Recuperando lista de objetos JSON.");
            try
            {
                jsonNodes = JsonConvert.DeserializeObject<List<Alumno>>(data);
                if (jsonNodes == null)
                {
                    log.Debug("Fichero vacío. No se han recuperado alumnos. Inicializando lista nueva.");
                    jsonNodes = new List<Alumno>();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
            jsonNodes.Add(alumno);

            var resultJSONList = JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
            fileManager.WriteToJson(path, resultJSONList);
            return JsonConvert.DeserializeObject<List<Alumno>>(fileManager.RetrieveJSONData(path)).Last();
        }
    }
}
