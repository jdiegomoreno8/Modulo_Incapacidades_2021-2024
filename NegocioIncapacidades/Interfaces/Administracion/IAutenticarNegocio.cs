using LibreriasIncapacidades.Modelos;
using System;

namespace NegocioIncapacidades
{
    public interface IAutenticarNegocio
    {
		bool VerificarUsuario(Int64 idHercules, Login login, Usuario usuario);

		bool VerificarUsuarioEntidad(Perfil perfil);

		bool AutorizarToken();

	}
}
