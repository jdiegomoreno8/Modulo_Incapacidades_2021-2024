using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class ModalidadRealizacionConsultaNegocio : IModalidadRealizacionConsultaNegocio
    {
        readonly IAccesoDatosReadOnly modalidadRealizacionConsultaRepositorio;
        public ModalidadRealizacionConsultaNegocio(IAccesoDatosReadOnly modalidadRealizacionConsultaRepositorioIn)
        {
            modalidadRealizacionConsultaRepositorio = modalidadRealizacionConsultaRepositorioIn;
        }
        public IList<ModalidadRealizacionConsulta> Consultar_Todos_Modalidad_Realizacion_Consulta()
        {
            return modalidadRealizacionConsultaRepositorio.Consultar_Modalidad_Realizacion_Consulta();
        }

    }
}
