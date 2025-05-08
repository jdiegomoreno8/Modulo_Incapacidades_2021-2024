using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class FinalidadConsultaNegocio
    {
        readonly IAccesoDatosReadOnly finalidadConsultaRepositorio;

        public FinalidadConsultaNegocio(IAccesoDatosReadOnly finalidadConsultaRepositorioIn)
        {
            finalidadConsultaRepositorio = finalidadConsultaRepositorioIn;
        }
        public IList<FinalidadConsulta> Consultar_Todos_Finalidad_Consulta()
        {
            return finalidadConsultaRepositorio.Consultar_Finalidad_Consulta();
        }


    }
}
