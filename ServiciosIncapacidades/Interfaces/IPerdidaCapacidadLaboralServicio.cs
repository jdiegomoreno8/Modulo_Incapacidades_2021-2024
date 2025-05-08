using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IPerdidaCapacidadLaboralServicio
    {
        IEnumerable<PerdidaCapacidadLaboral> Consultar_PerdidaCapacidadLaboral(Int64 id_concepto_registro);

        RespuestBD AdicionarPerdidaCapacidadLaboral(PerdidaCapacidadLaboral pcl);
    }

    
}
