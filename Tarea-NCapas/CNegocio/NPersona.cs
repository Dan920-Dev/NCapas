
using System.Data;
using CDatos;
using CEntidades;
namespace CNegocio
{
   public class NPersona
    {
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar();
        }

        public static string Insertar(string Nombre, string Apellido, string Telefono, int Edad)
        {
            DPersona Datos = new DPersona();
            string Existe = Datos.Existe(Nombre);
            if(Existe.Equals("1"))
            {
                return "La Persona ya Existe";
            }
            else
            {
                Persona Obj = new Persona();
                Obj.nombre = Nombre;
                Obj.apellido = Apellido;
                Obj.edad = Edad;
                Obj.telefono = Telefono;
                return Datos.Insertar(Obj); 
            }

            
        }
    }
}
