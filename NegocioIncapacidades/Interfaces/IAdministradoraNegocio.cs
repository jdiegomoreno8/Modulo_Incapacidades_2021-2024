using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
{
    public interface IAdministradoraNegocio
    {
        public IList<Administradoras> Consultar_Todos_Administradoras(string codRegimen, string tipoAdministradora);
    }
}
