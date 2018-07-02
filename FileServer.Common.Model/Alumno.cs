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

        public Alumno(string id, string nombre, string apellidos, string dNI)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            DNI = dNI;
        }

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
            var hashCode = -875667990;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            return hashCode;
        }

        //public override int GetHashCode()
        //{
        //    return this.Id.GetHashCode() ^ this.Nombre.GetHashCode() ^ this.Apellidos.GetHashCode() ^ this.DNI.GetHashCode();
        //}
    }
}
