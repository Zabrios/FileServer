using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Common.Model
{
    public class Alumno
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }

        public override bool Equals(object obj)
        {
            Alumno alumno = obj as Alumno;
            if (obj == null)
                return false;

            return Id == alumno.Id &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   DNI == alumno.DNI;
        }

        public override string ToString()
        {
            return string.Format(@"Id: {0}, Nombre: {1}, 
                                   Apellidos: {2}, DNI: {3}",
                                   Id, Nombre, Apellidos, DNI);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Nombre.GetHashCode() ^ this.Apellidos.GetHashCode() ^ this.DNI.GetHashCode();
        }
    }
}
