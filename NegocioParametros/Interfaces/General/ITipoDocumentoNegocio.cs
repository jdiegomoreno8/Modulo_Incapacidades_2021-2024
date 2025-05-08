using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
    public interface ITipoDocumentoNegocio
    {
        IList<TipoDocumento> Consultar_Todos_Tipo_Documento();
    }
}
