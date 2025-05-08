using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
    public class AdministradoraNegocio : IAdministradoraNegocio
    {
        readonly IAccesoDatosReadOnly administradoraRepositorio;
        readonly IAccesoDatosDataWrite _administradoraWriteRepositorio;

        public AdministradoraNegocio(IAccesoDatosReadOnly administradoraRepositorioIn, IAccesoDatosDataWrite administradoraWriteRepositorio)
        {
            administradoraRepositorio = administradoraRepositorioIn;
            _administradoraWriteRepositorio = administradoraWriteRepositorio;
        }
        
        public IList<Administradoras> Consultar_Todos_Administradoras(string codRegimen, string tipoAdministradora)
        {
            //return administradoraRepositorio.Consultar_Administradora(codRegimen, tipoAdministradora);
            return (IList<Administradoras>)administradoraRepositorio.Consultar_Administradora(codRegimen, tipoAdministradora);
        }

        public IList<Administradoras> Actualizar_Administradora(Administradoras administradora)
        {
            _administradoraWriteRepositorio.Actualizar_Administradora(administradora);

            return null;
        }
    }
}
