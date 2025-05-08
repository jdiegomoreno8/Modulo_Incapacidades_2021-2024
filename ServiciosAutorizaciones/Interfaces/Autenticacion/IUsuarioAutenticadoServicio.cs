using System;
using System.Collections.Generic;
using LibreriasAutorizaciones.Modelos;

namespace ServiciosAutorizaciones.Autenticacion
{
	public interface IUsuarioAutenticadoServicio
    {
		bool UsuarioValido(Int64 idHercules, Login login, Usuario usuario, out string Token, out string refreshToken);
		bool ActualizarPerfilUsuario(Perfil  perfil);
		bool AutorizarToken();
		string ActualizarDatosToken(Usuario usuario);
		IList<Usuario> ConsultarUsuarioPorNombreUsuario(string nombreUsuario);


    }

}
