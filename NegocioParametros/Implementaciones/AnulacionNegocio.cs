using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace NegocioParametros
{
    public class AnulacionNegocio : IAnulacionNegocio
    {
        readonly IAccesoDatosDataWrite incapacidadesRepositorio;
        //readonly AccesoDatosReadOnly incapacidadesrepositorioRead;

        public AnulacionNegocio(IAccesoDatosDataWrite incapacidadesRepositorioIn)
        {
            incapacidadesRepositorio = incapacidadesRepositorioIn;
            //incapacidadesrepositorioRead = new AccesoDatosReadOnly(conexion);
        }

        public int AnularIncapacidad(IncapacidadAnulada incapacidadesanulada)
        {
            return incapacidadesRepositorio.AnularIncapacidad(incapacidadesanulada);
        }
        
    }
}
