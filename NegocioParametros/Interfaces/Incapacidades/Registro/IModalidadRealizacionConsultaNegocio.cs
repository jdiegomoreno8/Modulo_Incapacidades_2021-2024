using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public interface IModalidadRealizacionConsultaNegocio
   {
        IList<ModalidadRealizacionConsulta> Consultar_Todos_Modalidad_Realizacion_Consulta();
   }
}
