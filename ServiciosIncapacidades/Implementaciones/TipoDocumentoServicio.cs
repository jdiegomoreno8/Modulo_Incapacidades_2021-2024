using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public class TipoDocumentoServicio: ITipoDocumentoServicio
    {
        private readonly ITipoDocumentoNegocio TipoDocumentoNegocio;
        public TipoDocumentoServicio(ITipoDocumentoNegocio TipoDocumentoNegocioIn)
        {
            TipoDocumentoNegocio = TipoDocumentoNegocioIn;
        }

        public IEnumerable<TipoDocumento> Consultar_Tipo_Documento()
        {
            var ListaTipoDocumento = TipoDocumentoNegocio.Consultar_Todos_Tipo_Documento();
            return ListaTipoDocumento;
        }
    }
}
