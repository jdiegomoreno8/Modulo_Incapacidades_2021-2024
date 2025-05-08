using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades

{
   public class FinalidadConsultaServicio : IFinalidadConsultaServicio
    {
        private readonly IFinalidadConsultaServicio finalidadConsultaNegocio;
        public FinalidadConsultaServicio(IFinalidadConsultaServicio FinalidadConsultaServicioNegocioIn) 
        {
            finalidadConsultaNegocio = FinalidadConsultaServicioNegocioIn;
        }
       
        public IEnumerable<FinalidadConsulta> Consultar_Finalidad_Consulta()
        {
            var ListaFinalidadConsulta = finalidadConsultaNegocio.Consultar_Finalidad_Consulta();
            return ListaFinalidadConsulta;
        }
    }
}
