using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using System;

namespace LibreriasIncapacidades.AccesoDatos
{
	public interface IAccesoDatosReadOnlyAdmin
	{
        List<Funcionalidad> TraerFuncionalidades(int idRol);
        List<PerfilComple> TraerIDUsuario(Perfil perfil);

        List<Funcionalidad> traer_funcionalidades(int idRol);
        List<PerfilComple> traer_idUsuario(Perfil perfil);

    }
}
