using Microsoft.Extensions.Configuration;
using System.IO;

namespace LibreriasIncapacidades.AccesoDatos
{
    public class ConexionMaestroPriorizado : IConexion
    {
        //private static IConfiguration _configuration;

        /// <summary>
        /// OBTIENE CONEXION BBDD
        /// </summary>
        /// <returns>CADENA DE CONEXION</returns>
        public string ObtenerConexion()
        {
            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            return _configuration.GetConnectionString("DatabaseNameConnStringMaestroPriorizado");
        }
    }
}
