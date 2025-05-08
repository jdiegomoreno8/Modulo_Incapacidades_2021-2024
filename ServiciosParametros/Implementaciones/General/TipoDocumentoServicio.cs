using LibreriasParametros.Modelos.General;
using System.Collections.Generic;
using NegocioParametros.General;

namespace ServiciosParametros.General
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
