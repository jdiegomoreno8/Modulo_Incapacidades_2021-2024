using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
   public class ModalidadRealizacionConsultaServicio : IModalidadRealizacionConsultaServicio
    {
        private readonly IModalidadRealizacionConsultaNegocio modalidadRealizacionConsultaNegocio;
        public ModalidadRealizacionConsultaServicio(IModalidadRealizacionConsultaNegocio modalidadRealizacionConsultaNegocioIn)
        {
            modalidadRealizacionConsultaNegocio = modalidadRealizacionConsultaNegocioIn;
        }

        public IEnumerable<ModalidadRealizacionConsulta> Consultar_Modalidad_Realizacion_Consulta()
        {
            var ListaModalidadRealizacionConsulta = modalidadRealizacionConsultaNegocio.Consultar_Todos_Modalidad_Realizacion_Consulta();
            return ListaModalidadRealizacionConsulta;
        }

    }
}