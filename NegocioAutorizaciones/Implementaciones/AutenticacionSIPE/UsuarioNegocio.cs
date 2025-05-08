using LibreriasAutorizaciones.AccesoDatos;
using LibreriasAutorizaciones.Modelos;
using NegocioAutorizaciones.Autenticacion;
using System.Collections.Generic;

namespace NegocioAutorizaciones
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        readonly IAccesoDatosDataWriteAdmin usuarioRepositorioWrite;
        readonly IAccesoDatosReadOnlyAdmin usuarioRepositorioReadOnly;

        public UsuarioNegocio(IAccesoDatosDataWriteAdmin usuarioRepositorioWrite, IAccesoDatosReadOnlyAdmin usuarioRepositorioReadOnly)
        {
            this.usuarioRepositorioWrite = usuarioRepositorioWrite;
            this.usuarioRepositorioReadOnly = usuarioRepositorioReadOnly;
        }

        public string ActualizarUsuarioDatosToken(Usuario usuario)
        {
            return usuarioRepositorioWrite.ActualizarDatosToken(usuario).resultado;
        }

        public IList<Usuario> ConsultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return usuarioRepositorioReadOnly.ConsultarUsuarioPorNombre(nombreUsuario);
        }

    }
}
