using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
   public interface IModalidadRealizacionConsultaServicio
    {
        public IEnumerable<ModalidadRealizacionConsulta> Consultar_Modalidad_Realizacion_Consulta();
    }
}
