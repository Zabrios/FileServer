using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Common.Model;
using Newtonsoft.Json;
using log4net;
using FileServer.Infrastucture.Repository.Interfaces;

namespace FileServer.Infrastucture.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        //(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IFileManager FManager { get; set; }

        public AlumnoRepository(IFileManager fm)
        {
            //log4net.Config.XmlConfigurator.Configure();
            FManager = fm;
        }

        public AlumnoRepository()
        {
        }

        public Alumno Add(Alumno alumno)
        {
            List<Alumno> jsonNodes = null;

            //log.Debug("alumno " + alumno.ToString());
            //log.Debug("path = " + FileManager.FilePath);
            FManager.CreateFile();
            //FileManager.CreateJSONFileIfNonexistent();
            var data = FileManager.RetrieveJSONData();
            try
            {
                //log.Debug("Recuperando lista de objetos JSON.");
                jsonNodes = JsonConvert.DeserializeObject<List<Alumno>>(data);
                if (jsonNodes == null)
                {
                    //log.Debug("Fichero vacío. No se han recuperado alumnos. Inicializando lista nueva.");
                    jsonNodes = new List<Alumno>();
                }

                jsonNodes.Add(alumno);

                var resultJSONList = JsonConvert.SerializeObject(jsonNodes, Formatting.Indented);
                FileManager.WriteToJson(resultJSONList);
                return JsonConvert.DeserializeObject<List<Alumno>>(FileManager.RetrieveJSONData()).Last();
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                throw ex;
            }
        }
    }
}
