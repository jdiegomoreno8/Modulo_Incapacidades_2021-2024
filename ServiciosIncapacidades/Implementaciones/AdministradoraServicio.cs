using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
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
    }
}
