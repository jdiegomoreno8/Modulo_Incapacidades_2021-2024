using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public interface IModalidadRealizacionConsultaNegocio
   {
        IList<ModalidadRealizacionConsulta> Consultar_Todos_Modalidad_Realizacion_Consulta();
   }
}
