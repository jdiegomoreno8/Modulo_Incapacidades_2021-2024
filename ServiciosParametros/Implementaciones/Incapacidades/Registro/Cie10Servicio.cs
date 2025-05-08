using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
    public class Cie10Servicio : ICie10Servicio
    {
        private readonly ICie10Negocio cie10Negocio;
        public Cie10Servicio(ICie10Negocio cie10NegocioIn)
        {
            cie10Negocio = cie10NegocioIn;
        }

        public IEnumerable<Cie10> ObtenerCie10()
        {
            var ListaCie10 = cie10Negocio.ObtenerTodosCie10();
            return ListaCie10;
        }

        public IEnumerable<Cie10> ObtenerCie10(string value)
        {
            var ListaCie10 = cie10Negocio.ObtenerTodosCie10(value);
            return ListaCie10;
        }
    }
}
