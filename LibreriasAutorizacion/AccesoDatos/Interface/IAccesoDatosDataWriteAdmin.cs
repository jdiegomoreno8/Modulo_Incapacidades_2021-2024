using System;
using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;

namespace LibreriasAutorizaciones.AccesoDatos
{
	public interface IAccesoDatosDataWriteAdmin
	{
        bool VerificarUsuario(Int64 idHercules, Login login, Usuario usuario);
        bool VerificarUsuarioEntidad(Perfil perfil);
        bool verificar_usuario(Int64 idHercules, Login login, Usuario usuario);
        bool verificar_usuario_entidad(Perfil perfil);

        RespuestBD ActualizarDatosToken(Usuario usuario);
    }
}
