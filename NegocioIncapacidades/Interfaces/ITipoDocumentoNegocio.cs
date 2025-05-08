using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public interface ITipoDocumentoNegocio
    {
        IList<TipoDocumento> Consultar_Todos_Tipo_Documento();
    }
}
