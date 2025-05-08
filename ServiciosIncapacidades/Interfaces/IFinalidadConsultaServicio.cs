using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface IFinalidadConsultaServicio
    {
        public IEnumerable<FinalidadConsulta> Consultar_Finalidad_Consulta();
    }
}
