using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;
using ServiciosIncapacidades;

namespace ServiciosIncapacidades
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