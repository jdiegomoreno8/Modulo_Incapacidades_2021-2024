using System.Data;

namespace LibreriasParametros.AccesoDatos
{
    public interface IConexionFactory
    {
        IDbConnection CrearConexion(EnumConexion enumConexion);
    }
}
