using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace ServiciosParametros.General
{
    public interface ITipoDocumentoServicio
    {
        public IEnumerable<TipoDocumento> Consultar_Tipo_Documento();
    }
}
