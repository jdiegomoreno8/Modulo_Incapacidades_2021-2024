using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using System;

namespace NegocioIncapacidades
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
