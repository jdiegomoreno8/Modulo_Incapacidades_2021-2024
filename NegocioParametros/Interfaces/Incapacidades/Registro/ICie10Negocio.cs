using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface ICie10Negocio{

        public IList<Cie10> ObtenerTodosCie10();
        public IList<Cie10> ObtenerTodosCie10(string value);

    }
}
