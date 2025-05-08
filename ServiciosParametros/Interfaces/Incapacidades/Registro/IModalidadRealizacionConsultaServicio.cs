using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
   public interface IModalidadRealizacionConsultaServicio
    {
        public IEnumerable<ModalidadRealizacionConsulta> Consultar_Modalidad_Realizacion_Consulta();
    }
}
