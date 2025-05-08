using ServiciosIncapacidades.Interfaces;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using NegocioIncapacidades;
using System;

namespace ServiciosIncapacidades.Implementaciones
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
