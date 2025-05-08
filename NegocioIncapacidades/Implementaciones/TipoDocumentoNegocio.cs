using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
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
            return tipoDocumentoRepositorio.Consultar_Tipo_Documento();
        }
    }
}
