using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface IFinalidadConsultaServicio
    {
        public IEnumerable<FinalidadConsulta> Consultar_Finalidad_Consulta();
    }
}
