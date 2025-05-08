using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
    public class TipoDocumentoNegocio : ITipoDocumentoNegocio
    {
        readonly IAccesoDatosReadOnly tipoDocumentoRepositorio;

        public TipoDocumentoNegocio(IAccesoDatosReadOnly tipoDocumentoRepositorioIn)
        {
            tipoDocumentoRepositorio = tipoDocumentoRepositorioIn;
        }
        public IList<TipoDocumento> Consultar_Todos_Tipo_Documento()
        {
            //return tipoDocumentoRepositorio.Consultar_Tipo_Documento();
            return (IList<TipoDocumento>)tipoDocumentoRepositorio.Consultar_Tipo_Documento();
        }
    }
}
