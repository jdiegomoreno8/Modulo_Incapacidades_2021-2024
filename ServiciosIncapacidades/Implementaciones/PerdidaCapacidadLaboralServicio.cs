using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades.Implementaciones
{
    public class PerdidaCapacidadLaboralServicio: IPerdidaCapacidadLaboralServicio
    {
        private readonly IPerdidaCapacidadLaboralNegocio PerdidaCapacidadLaboralNegocio;
        public PerdidaCapacidadLaboralServicio(IPerdidaCapacidadLaboralNegocio PerdidaCapacidadLaboralNegocioIn)
        {
            PerdidaCapacidadLaboralNegocio = PerdidaCapacidadLaboralNegocioIn;
        }
        public IEnumerable<PerdidaCapacidadLaboral> Consultar_PerdidaCapacidadLaboral(Int64 id_concepto_registro)
        {
            var ListaPerdidaCapacidadLaboral = PerdidaCapacidadLaboralNegocio.Consultar_TodosPerdidaCapacidadLaboral(id_concepto_registro);
            return ListaPerdidaCapacidadLaboral;
        }

        public RespuestBD AdicionarPerdidaCapacidadLaboral(PerdidaCapacidadLaboral pcl)
        {
            return PerdidaCapacidadLaboralNegocio.NuevaPerdidacCapacidadLaboral(pcl);
        }
    }
}
