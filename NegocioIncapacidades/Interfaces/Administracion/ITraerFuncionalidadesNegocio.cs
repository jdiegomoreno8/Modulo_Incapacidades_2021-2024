using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using System;

namespace NegocioIncapacidades
{
    public interface ITraerFuncionalidadesNegocio
    {
        List<Funcionalidad> CargarMenu(int idRol);
        List<PerfilComple> BuscarIDPerfil(Perfil perfil);
    }


}
