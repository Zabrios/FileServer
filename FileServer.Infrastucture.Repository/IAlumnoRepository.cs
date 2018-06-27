using FileServer.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Infrastucture.Repository
{
    public interface IAlumnoRepository
    {
        // should return Alumno object instead of a bool
        bool Add(Alumno alumno);
    }
}
