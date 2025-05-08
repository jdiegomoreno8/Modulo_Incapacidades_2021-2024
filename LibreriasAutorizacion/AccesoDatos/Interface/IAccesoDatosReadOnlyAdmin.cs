using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using System.Collections.Generic;


namespace LibreriasAutorizaciones.AccesoDatos
{
	public interface IAccesoDatosReadOnlyAdmin
	{
        List<Funcionalidad> TraerFuncionalidades(int idRol);
        List<PerfilComple> TraerIDUsuario(Perfil perfil);
        List<Funcionalidad> traer_funcionalidades(int idRol);
        List<PerfilComple> traer_idUsuario(Perfil perfil);
        List<Usuario> ConsultarUsuarioPorNombre(string nombreUsuario);
    }
}
