using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return modalidadRealizacionConsultaRepositorio.Consultar_Modalidad_Realizacion_Consulta();
            return (IList<ModalidadRealizacionConsulta>) modalidadRealizacionConsultaRepositorio.Consultar_Modalidad_Realizacion_Consulta();
        }

    }
}
