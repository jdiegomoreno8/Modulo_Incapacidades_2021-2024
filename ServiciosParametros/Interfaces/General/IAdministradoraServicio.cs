using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace ServiciosParametros.General
{
   public interface IAdministradoraServicio
    {
        IEnumerable<Administradoras> Consultar_Administradora(string codRegimen, string tipoAdministradora);
        IEnumerable<Administradoras> Actualizar_Administradora(Administradoras administradora);
    }
}
