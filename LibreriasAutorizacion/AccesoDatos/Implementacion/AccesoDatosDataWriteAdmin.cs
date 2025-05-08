using System;
using System.Data.SqlClient;
using System.Data;
using LibreriasAutorizaciones.Modelos;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using LibreriasAutorizaciones.Modelos.DTO;

namespace LibreriasAutorizaciones.AccesoDatos
{
	public class AccesoDatosDataWriteAdmin : IAccesoDatosDataWriteAdmin
    {

        private readonly IConexionFactory ConexionFactory;
        private readonly IDapperWrapper DapperWrapper;

        public static int iCommandTimeOut;

        public AccesoDatosDataWriteAdmin(IConexionFactory ConexionFactoryIn, IDapperWrapper dapperWrapper)
        {
            ConexionFactory = ConexionFactoryIn;
            DapperWrapper = dapperWrapper;

            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            iCommandTimeOut = Convert.ToInt32(_configuration.GetConnectionString("CommandTimeOutEXEC"));

        }

        public bool VerificarUsuario(Int64 idHercules, Login login, Usuario usuario)
        {
            return verificar_usuario(idHercules, login, usuario);
        }

        public bool VerificarUsuarioEntidad(Perfil perfil)
        {
           return verificar_usuario_entidad(perfil);
        }

        public bool verificar_usuario( Int64 idHercules, Login login, Usuario usuario)
        {
            bool retorno;

            using (SqlConnection conexion = (SqlConnection)ConexionFactory.CrearConexion(EnumConexion.WriteAdmin))
            {
                conexion.Open();

                SqlCommand command = new SqlCommand("Consultar_Usuario", conexion);
                command.CommandTimeout = iCommandTimeOut;
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCodRetorno = new SqlParameter("retorno", SqlDbType.Bit);
                paramCodRetorno.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramCodRetorno);

                command.Parameters.AddWithValue("id_usuario_hercules", idHercules);
                command.Parameters.AddWithValue("tipo_documento", usuario.tipoDocumento);
                command.Parameters.AddWithValue("numero_documento", usuario.numeroDocumento);
                command.Parameters.AddWithValue("primer_nombre",usuario.primerNombre);
                command.Parameters.AddWithValue("segundo_nombre",usuario.segundoNombre);
                command.Parameters.AddWithValue("primer_apellido",usuario.primerApellido);
                command.Parameters.AddWithValue("segundo_apellido",usuario.segundoApellido);
                command.Parameters.AddWithValue("nombre_usuario",login.NombreUsuario);
                command.Parameters.AddWithValue("contrasena",login.Contrasena);
                command.Parameters.AddWithValue("registro_profesional",usuario.registroProfesional);
                command.Parameters.AddWithValue("profesion",usuario.profesion);
                command.Parameters.AddWithValue("email",usuario.email);
                command.Parameters.AddWithValue("tipo_usuario",usuario.tipoUsuario);
                command.Parameters.AddWithValue("programa_usuario",usuario.programaUsuario);
                command.Parameters.AddWithValue("bloqueado",usuario.bloqueado);
                command.Parameters.AddWithValue("deshabilitado",usuario.deshabilitado);
                command.Parameters.AddWithValue("requiere_cambio_clave",usuario.requiereCambioClave);
                command.Parameters.AddWithValue("ultima_fecha_actualizacion",usuario.fechaUltActualizacion);

                command.ExecuteNonQuery();

                retorno = Convert.ToBoolean(command.Parameters["retorno"].Value);

                conexion.Close();
            }
            return retorno;
        }
        
        public bool verificar_usuario_entidad(Perfil perfil)
        {
            bool retorno;
            using (SqlConnection conexion = (SqlConnection)ConexionFactory.CrearConexion(EnumConexion.WriteAdmin))
            {
                conexion.Open();

                SqlCommand command = new SqlCommand("Consultar_Usuario_Entidad", conexion);
                command.CommandTimeout = iCommandTimeOut;
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCodRetorno = new SqlParameter("retorno", SqlDbType.Bit);
                paramCodRetorno.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramCodRetorno);

                command.Parameters.AddWithValue("id_usuario_hercules", perfil.idUsuario2);
                command.Parameters.AddWithValue("codigo_entidad", perfil.codigoEntidad);
                command.Parameters.AddWithValue("id_rol_hercules", perfil.idRol);

                command.ExecuteNonQuery();

                    retorno = Convert.ToBoolean(command.Parameters["retorno"].Value);

                conexion.Close();
            }
            return retorno;
        }

        public RespuestBD ActualizarDatosToken(Usuario usuario)
        {
            object dataObject = new { };
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.WriteAdmin);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Actualizar_Datos_token", dataObject = new
                {
                    nombre_usuario = usuario.nombreUsuario,
                    access_token = usuario.access_token,
                    refresh_token = usuario.refresh_token,
                    date_expiration = usuario.date_expiration//DateTime.Now.AddMinutes(5)
                },
                commandType: CommandType.StoredProcedure);

                if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                {
                    throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                }

                return result.ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

    }
}
