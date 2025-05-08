using System.Data;

namespace LibreriasAutorizaciones.AccesoDatos
{
    public interface IConexionFactory
    {
        IDbConnection CrearConexion(EnumConexion enumConexion);
    }
}
