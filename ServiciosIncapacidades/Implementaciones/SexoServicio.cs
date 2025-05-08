using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
    public class SexoServicio : ISexoServicio
    {

        private readonly ISexoNegocio sexoNegocio;
        public SexoServicio(ISexoNegocio sexoNegocioIn)
        {
            sexoNegocio = sexoNegocioIn;
        }

        public IEnumerable<Sexo> Consultar_Sexo()
        {
            var ListaSexo = sexoNegocio.Consultar_Todos_Sexo();
            return ListaSexo;
        }
    }
}
