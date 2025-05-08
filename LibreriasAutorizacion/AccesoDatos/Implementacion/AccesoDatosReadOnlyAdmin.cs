using System;
using System.Data.SqlClient;
using System.Data;
using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace LibreriasAutorizaciones.AccesoDatos
{
	public class AccesoDatosReadOnlyAdmin : IAccesoDatosReadOnlyAdmin
    {
        private readonly IConexionFactory ConexionFactory;
        private readonly IDapperWrapper DapperWrapper;

        public static int iCommandTimeOut;

        public AccesoDatosReadOnlyAdmin(IConexionFactory ConexionFactoryIn, IDapperWrapper dapperWrapper)
        {
            ConexionFactory = ConexionFactoryIn;
            DapperWrapper = dapperWrapper;

            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            iCommandTimeOut = Convert.ToInt32(_configuration.GetConnectionString("CommandTimeOutEXEC"));
        }

        public List<Funcionalidad> TraerFuncionalidades(int idRol)
        {
            return traer_funcionalidades(idRol);
        }


        //public Int64 TraerIDUsuario(Perfil perfil)
        public List<PerfilComple> TraerIDUsuario(Perfil perfil)
        {
            return traer_idUsuario(perfil);
        }



        public List<Funcionalidad> traer_funcionalidades(int idRol)
        {
            using (SqlConnection conexion = (SqlConnection)ConexionFactory.CrearConexion(EnumConexion.ReadOnlyAdmin))
            {
                conexion.Open();

                SqlDataAdapter DataAdapter = new SqlDataAdapter("Consultar_Funcionalidad", conexion);
                DataAdapter.SelectCommand.CommandTimeout = iCommandTimeOut;
                DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataAdapter.SelectCommand.Parameters.AddWithValue("id_rol", idRol);
                DataSet DS = new DataSet();

                DataAdapter.Fill(DS, "Consultar_Funcionalidad");

                var lista = DS.Tables[0].AsEnumerable().Select(dataRow => new Funcionalidad
                {
                    id_funcionalidad = dataRow.Field<Int16>("id_funcionalidad"),
                    nombre = dataRow.Field<string>("nombre"),
                    ruta = dataRow.Field<string>("ruta")
                }).ToList();

                DataAdapter.Dispose();
                conexion.Close();

                return lista;

            }
        }

        public List<PerfilComple> traer_idUsuario(Perfil perfil)
        //public  Int64 traer_idUsuario(Perfil perfil)
        {
            //Int64 retorno;

            using (SqlConnection conexion = (SqlConnection)ConexionFactory.CrearConexion(EnumConexion.ReadOnlyAdmin))
            {
                conexion.Open();

                //SqlCommand command = new SqlCommand("Consultar_Usuario_Perfil", conexion);
                //command.CommandTimeout = iCommandTimeOut;
                //command.CommandType = CommandType.StoredProcedure;

                //SqlParameter paramCodRetorno = new SqlParameter("retorno", SqlDbType.BigInt);
                //paramCodRetorno.Direction = ParameterDirection.Output;
                //command.Parameters.Add(paramCodRetorno);

                //command.Parameters.AddWithValue("id_usuario_hercules", perfil.idUsuario2);
                //command.Parameters.AddWithValue("codigo_entidad", perfil.codigoEntidad);
                //command.Parameters.AddWithValue("id_rol_hercules", perfil.idRol);

                //command.ExecuteNonQuery();

                //retorno = Convert.ToInt64(command.Parameters["retorno"].Value);

                //conexion.Close();


                SqlDataAdapter DataAdapter = new SqlDataAdapter("Consultar_Usuario_Perfil", conexion);
                DataAdapter.SelectCommand.CommandTimeout = iCommandTimeOut;
                DataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataAdapter.SelectCommand.Parameters.AddWithValue("id_usuario_hercules", perfil.idUsuario2);
                DataAdapter.SelectCommand.Parameters.AddWithValue("codigo_entidad", perfil.codigoEntidad);
                DataAdapter.SelectCommand.Parameters.AddWithValue("id_rol_hercules", perfil.idRol);
                DataSet DS = new DataSet();

                DataAdapter.Fill(DS, "Consultar_Usuario_Perfil");
                
                var lista = DS.Tables[0].AsEnumerable().Select(dataRow => new PerfilComple
                {
                    idEntidad = dataRow.Field<int>("id_entidad"),
                    idRol = dataRow.Field<Int16>("id_rol"),
                    idUsuarioEntidadRol = dataRow.Field<Int64>("id_usuario_entidad_rol"),
                    codDepto = dataRow.Field<string>("cod_depto"),
                    codMunicipio = dataRow.Field<string>("cod_municipio")
                }).ToList();

                DataAdapter.Dispose();
                conexion.Close();

                return lista;
            }
           // return retorno;
        }
        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }

        public List<Usuario> ConsultarUsuarioPorNombre(string nombreUsuario)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnlyAdmin))
            {
                var result = DapperWrapper.Query<Usuario>(connection, "dbo.Consultar_Usuario_Por_Nombre", new { usuario_nombre = nombreUsuario },
                                    CommandType.StoredProcedure);
                return result.ToList();
            };
        }


    }
}
