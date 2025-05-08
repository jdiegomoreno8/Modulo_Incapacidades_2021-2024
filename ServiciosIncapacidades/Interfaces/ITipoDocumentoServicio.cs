using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface ITipoDocumentoServicio
    {
        public IEnumerable<TipoDocumento> Consultar_Tipo_Documento();
    }
}
