using Microsoft.Extensions.Configuration;
using System.IO;

namespace LibreriasIncapacidades.AccesoDatos
{
    public interface IConexion
    {
        //private static IConfiguration _configuration;

        /// <summary>
        /// OBTIENE CONEXION BBDD
        /// </summary>
        /// <returns>CADENA DE CONEXION</returns>
        //public string ObtenerConexionSoloLectura();

        //public string ObtenerConexionEscritura();
        string ObtenerConexion();

    }
}
