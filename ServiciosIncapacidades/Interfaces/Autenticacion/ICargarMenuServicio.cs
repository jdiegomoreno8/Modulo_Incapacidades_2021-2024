using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using System;

namespace ServiciosIncapacidades.Interfaces
{
	public interface ICargarMenuServicio
	{
		List<Funcionalidad> TraerFuncionalidades(int idRol);
		List<PerfilComple> TraerIDPerfil(Perfil perfil);
	}

}
