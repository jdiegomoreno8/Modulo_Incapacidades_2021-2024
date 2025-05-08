using System;
using ServiciosIncapacidades.Interfaces;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;

namespace ServiciosIncapacidades.Implementaciones
{
	public class UsuarioAutenticadoServicio : IUsuarioServicio
	{
		private readonly IAutenticarNegocio autenticarNegocio;

        public UsuarioAutenticadoServicio(IAutenticarNegocio autenticarNegocioIn)
        {
			autenticarNegocio = autenticarNegocioIn;
		}

		public bool UsuarioValido(Int64 idHercules, Login login, Usuario usuario) 
		{
			return autenticarNegocio.VerificarUsuario(idHercules, login, usuario);
		}

		public bool ActualizarPerfilUsuario(Perfil perfil)
		{
			return autenticarNegocio.VerificarUsuarioEntidad(perfil);
		}

		public bool AutorizarToken()
		{ return true; }

	}
}
