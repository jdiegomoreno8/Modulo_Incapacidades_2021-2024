using LibreriasAutorizaciones.Modelos;
using System;

namespace NegocioAutorizaciones.Autenticacion
{
    public interface IAutenticarNegocio
    {
		bool VerificarUsuario(Int64 idHercules, Login login, Usuario usuario);

		bool VerificarUsuarioEntidad(Perfil perfil);

		bool AutorizarToken();

	}
}
