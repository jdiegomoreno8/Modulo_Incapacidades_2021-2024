using LibreriasParametros.Modelos.General;
using System.Collections.Generic;
using NegocioParametros.General;

namespace ServiciosParametros.General
{
   public class AdministradoraServicio: IAdministradoraServicio
    {
        private readonly IAdministradoraNegocio administradoraNegocio;
        public AdministradoraServicio(IAdministradoraNegocio administradoraNegocioIn)
        {
            administradoraNegocio = administradoraNegocioIn;
        }

        public IEnumerable<Administradoras> Consultar_Administradora(string codRegimen, string tipoAdministradora)
        {
            var ListaAdministradora = administradoraNegocio.Consultar_Todos_Administradoras(codRegimen, tipoAdministradora);
            return ListaAdministradora;
        }

        public IEnumerable<Administradoras> Actualizar_Administradora(Administradoras administradora)
        {
            var ListaAdministradora = administradoraNegocio.Actualizar_Administradora(administradora);
            return ListaAdministradora;
        }
    }
}
