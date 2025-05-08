using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
    public interface IAdministradoraNegocio
    {
        public IList<Administradoras> Consultar_Todos_Administradoras(string codRegimen, string tipoAdministradora);
        public IList<Administradoras> Actualizar_Administradora(Administradoras administradora);
    }
}
