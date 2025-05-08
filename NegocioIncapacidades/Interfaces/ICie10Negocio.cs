using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace Negocio
{
    public interface ICie10Negocio{

        public IList<Cie10> ObtenerTodosCie10();
        public IList<Cie10> ObtenerTodosCie10(string value);

    }
}
