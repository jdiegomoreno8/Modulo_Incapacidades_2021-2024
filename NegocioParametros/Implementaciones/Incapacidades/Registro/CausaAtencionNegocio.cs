using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public class CausaAtencionNegocio : ICausaAtencionNegocio
    {
        readonly IAccesoDatosReadOnly causaAtencionRepositorio;

        public CausaAtencionNegocio(IAccesoDatosReadOnly causaAtencionRepositorioIn)
        {
            causaAtencionRepositorio = causaAtencionRepositorioIn;
        }
        public IList<CausaAtencion> Consultar_Todos_Causa_Motivo_Atencion()
        {
            //return causaAtencionRepositorio.Consultar_Causa_Motivo_Atencion();
            return (IList<CausaAtencion>) causaAtencionRepositorio.Consultar_Causa_Motivo_Atencion();
        }


    }
}
