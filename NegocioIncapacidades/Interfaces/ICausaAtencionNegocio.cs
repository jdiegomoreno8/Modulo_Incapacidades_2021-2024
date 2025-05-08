using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public interface ICausaAtencionNegocio
    {
        IList<CausaAtencion> Consultar_Todos_Causa_Motivo_Atencion();
    }
}
