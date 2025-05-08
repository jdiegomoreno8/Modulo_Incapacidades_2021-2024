using LibreriasAutorizaciones.Modelos;
using System.Collections.Generic;

namespace NegocioAutorizaciones.Autenticacion
{
    public interface IUsuarioNegocio
    {
        string ActualizarUsuarioDatosToken(Usuario usuario);

        IList<Usuario> ConsultarUsuarioPorNombreUsuario(string nombreUsuario);
    }
}