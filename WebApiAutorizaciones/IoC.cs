using LibreriasAutorizaciones.AccesoDatos;
using Microsoft.Extensions.DependencyInjection;
using NegocioAutorizaciones;
using NegocioAutorizaciones.Autenticacion;
using ServiciosAutorizaciones;
using ServiciosAutorizaciones.Autenticacion;
using ServiciosAutorizaciones.Implementaciones.Autenticacion;

namespace WebApiAutorizaciones
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar acceso a datos
            services.AddTransient<IDapperWrapper, DapperWrapper>();
            services.AddTransient<IConexionFactory, ConexionFactory>();
            //services.AddTransient<IAccesoDatosReadOnly, AccesoDatosReadOnly>();
            //services.AddTransient<IAccesoDatosDataWrite, AccesoDatosDataWrite>();
            services.AddTransient<IAccesoDatosReadOnlyAdmin, AccesoDatosReadOnlyAdmin>();
            services.AddTransient<IAccesoDatosDataWriteAdmin, AccesoDatosDataWriteAdmin>();

            services.AddTransient<IAutenticarNegocio, AutenticarNegocio>();
            services.AddTransient<IUsuarioNegocio, UsuarioNegocio>();
            services.AddTransient<ITraerFuncionalidadesNegocio, TraerFuncionalidadesNegocio>();
            services.AddTransient<IAutorizacionTokenServicio, AutorizacionTokenServicio>();
            services.AddTransient<ICargarMenuServicio, CargarMenuServicio>();
            services.AddTransient<IUsuarioAutenticadoServicio, UsuarioAutenticadoServicio>();
            services.AddTransient<ITokenHandlerCustom, TokenHandlerCustom>(); 


            return services;
        }
    }
}
