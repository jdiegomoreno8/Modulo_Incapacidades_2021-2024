using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public class Cie10Negocio : ICie10Negocio
    {
        readonly IAccesoDatosReadOnly adr;

        public Cie10Negocio(IAccesoDatosReadOnly adrIn)
        {
            adr = adrIn;
        }
        public IList<Cie10> ObtenerTodosCie10()
        {
            //return adr.ConsultaCie10();
            return (IList<Cie10>) adr.ConsultaCie10();
        }
        public IList<Cie10> ObtenerTodosCie10(string value)
        {
            //return adr.ConsultaCie10(value);
            return (IList<Cie10>) adr.ConsultaCie10(value);
        }

    }
}
