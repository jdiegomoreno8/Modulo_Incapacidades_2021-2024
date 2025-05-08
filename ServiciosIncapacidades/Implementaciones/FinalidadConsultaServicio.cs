using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
   public class FinalidadConsultaServicio : IFinalidadConsultaServicio
    {
        public IEnumerable<FinalidadConsulta> Consultar_Finalidad_Consulta()
        {
            FinalidadConsultaNegocio finalidadConsultanegocio = new FinalidadConsultaNegocio();
            var ListaFinalidadConsulta = finalidadConsultanegocio.Consultar_Todos_Finalidad_Consulta();
            return ListaFinalidadConsulta;
        }
    }
}
