using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibreriasIncapacidades.AccesoDatos
{
    public interface IConexionFactory
    {
        IDbConnection CrearConexion(EnumConexion enumConexion);
    }
}
