using System;
using LibreriasIncapacidades.Modelos;

namespace ServiciosIncapacidades.Interfaces
{
	public interface IUsuarioServicio
	{
		bool UsuarioValido(Int64 idHercules, Login login, Usuario usuario);
		bool ActualizarPerfilUsuario(Perfil  perfil);
		bool AutorizarToken();

	}

}
