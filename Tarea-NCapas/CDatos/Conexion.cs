using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos
{
    public class Conexion
    {
        // Base nos ayuda a guardar el nombre de
        // la base que nos vamos a Conectar
        private string Base;
        private string servidor; // Indica el Servidor ya sea remota o local
        private bool seguridad;

        private static Conexion Con = null;

        private Conexion() // Constructor de la clase
        {
            this.Base = "Tarea1NCapasDB";
            this.servidor = "LAPTOP-9PM57NCA";
            this.seguridad = true;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                Cadena.ConnectionString = "Server=" + this.servidor + "; Database=" + this.Base + ";"; //Cadena de conexion
                if(this.seguridad)// Para autentificacion de Windows
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI";
                }          
            }
            catch(Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        public static Conexion getInstancia() // Verificamos si hay instancia, sino hay la crea y la devuelve
        {
            if(Con == null)
            {
                Con = new Conexion();
            }

            return Con;
        }
    }
}
