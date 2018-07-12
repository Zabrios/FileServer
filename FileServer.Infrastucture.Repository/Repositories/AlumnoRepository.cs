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
            try
            {
                return FManager.ProcessAlumnoData(alumno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
