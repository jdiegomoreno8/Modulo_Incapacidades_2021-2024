using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
{
    public class AdministradoraNegocio : IAdministradoraNegocio
    {
        readonly IAccesoDatosReadOnly administradoraRepositorio;
        
        public AdministradoraNegocio(IAccesoDatosReadOnly administradoraRepositorioIn)
        {
            administradoraRepositorio = administradoraRepositorioIn; // new AccesoDatosReadOnly(conexion);
        }
        
        public IList<Administradoras> Consultar_Todos_Administradoras(string codRegimen, string tipoAdministradora)
        {
            return administradoraRepositorio.Consultar_Administradora(codRegimen, tipoAdministradora);
        }
    }
}
