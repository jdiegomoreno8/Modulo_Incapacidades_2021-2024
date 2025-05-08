using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using System.Collections.Generic;

namespace ServiciosAutorizaciones.Autenticacion
{
	public interface ICargarMenuServicio
	{
		List<Funcionalidad> TraerFuncionalidades(int idRol);
		List<PerfilComple> TraerIDPerfil(Perfil perfil);
	}

}
