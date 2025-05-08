using System;
using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;

namespace NegocioIncapacidades
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
