using LibreriasAutorizaciones.AccesoDatos;
using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using System.Collections.Generic;

namespace NegocioAutorizaciones.Autenticacion
{
	public class TraerFuncionalidadesNegocio : ITraerFuncionalidadesNegocio
	{
		readonly IAccesoDatosReadOnlyAdmin cargarMenuRepositorioLectura;

		public TraerFuncionalidadesNegocio(IAccesoDatosReadOnlyAdmin cargarMenuRepositorioLecturaIn)
		{
			cargarMenuRepositorioLectura = cargarMenuRepositorioLecturaIn; // new AccesoDatosReadOnlyAdmin();
		}

		public List<Funcionalidad> CargarMenu(int idRol)
		{
			return cargarMenuRepositorioLectura.TraerFuncionalidades(idRol);
		}

		public List<PerfilComple> BuscarIDPerfil(Perfil perfil)
		{
			return cargarMenuRepositorioLectura.TraerIDUsuario(perfil);
		}

	}




}
