using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using System.Collections.Generic;

namespace NegocioAutorizaciones.Autenticacion
{
    public interface ITraerFuncionalidadesNegocio
    {
        List<Funcionalidad> CargarMenu(int idRol);
        List<PerfilComple> BuscarIDPerfil(Perfil perfil);
    }


}
