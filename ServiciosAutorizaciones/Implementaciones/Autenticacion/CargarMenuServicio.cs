using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using NegocioAutorizaciones.Autenticacion;
using System.Collections.Generic;

namespace ServiciosAutorizaciones.Autenticacion
{
	public class CargarMenuServicio : ICargarMenuServicio
	{
		private readonly ITraerFuncionalidadesNegocio traerFuncionalidaNegocio;

		public CargarMenuServicio(ITraerFuncionalidadesNegocio traerFuncionalidaNegocioIn)
        {
			traerFuncionalidaNegocio = traerFuncionalidaNegocioIn;
		}

		public List<Funcionalidad> TraerFuncionalidades(int idRol) 
		{
			return traerFuncionalidaNegocio.CargarMenu(idRol);
		}

		public List<PerfilComple> TraerIDPerfil(Perfil perfil)
		{
			return traerFuncionalidaNegocio.BuscarIDPerfil(perfil);
		}

	}
}
