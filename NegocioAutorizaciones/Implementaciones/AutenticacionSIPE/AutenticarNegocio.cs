using LibreriasAutorizaciones.AccesoDatos;
using LibreriasAutorizaciones.Modelos;
using System;

namespace NegocioAutorizaciones.Autenticacion
{
	public class AutenticarNegocio : IAutenticarNegocio
	{
		readonly IAccesoDatosDataWriteAdmin autenticarRepositorioEscritura;

		public AutenticarNegocio(IAccesoDatosDataWriteAdmin autenticarRepositorioEscrituraIn)
		{
			autenticarRepositorioEscritura = autenticarRepositorioEscrituraIn; // new AccesoDatosDataWriteAdmin();
		}

		public bool VerificarUsuario(Int64 idHercules, Login login, Usuario usuario)
		{
			return autenticarRepositorioEscritura.VerificarUsuario(idHercules, login, usuario);
		}

		public bool VerificarUsuarioEntidad(Perfil perfil)
		{
			return autenticarRepositorioEscritura.VerificarUsuarioEntidad(perfil);
		}

		public bool AutorizarToken()
		{ return true; }

	}




}
