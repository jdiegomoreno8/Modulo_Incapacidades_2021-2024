using LibreriasParametros.Modelos.General;
using System.Collections.Generic;
using NegocioParametros.General;

namespace ServiciosParametros.General
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
