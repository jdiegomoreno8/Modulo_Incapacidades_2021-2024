using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiIncapacidades.Modelos.DTO;

namespace NegocioIncapacidades.Interfaces
{
    public interface IPerdidaCapacidadLaboralNegocio
    {

        IList<PerdidaCapacidadLaboral> Consultar_TodosPerdidaCapacidadLaboral(Int64 id_concepto_registro);

        RespuestBD NuevaPerdidacCapacidadLaboral(PerdidaCapacidadLaboral pcl);
    }
}
