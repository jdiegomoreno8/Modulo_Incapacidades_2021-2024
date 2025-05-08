using LibreriasParametros.AccesoDatos;
using Microsoft.Extensions.DependencyInjection;
using NegocioParametros;
using NegocioParametros.General;
using NegocioParametros.Incapacidades;
using ServiciosParametros;
using ServiciosParametros.General;
using ServiciosParametros.Incapacidades;


namespace WebApiParametros
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar acceso a datos
            services.AddTransient<IDapperWrapper, DapperWrapper>();
            services.AddTransient<IConexionFactory, ConexionFactory>();
            services.AddTransient<IAccesoDatosReadOnly, AccesoDatosReadOnly>();
            services.AddTransient<IAccesoDatosDataWrite, AccesoDatosDataWrite>();

            // Inyectar negocios
            services.AddTransient<IAdministradoraNegocio, AdministradoraNegocio>();
            services.AddTransient<IGrupoServiciosNegocio, GrupoServiciosNegocio>();
            services.AddTransient<IOrigenNegocio, OrigenNegocio>();
            services.AddTransient<ICausaAtencionNegocio, CausaAtencionNegocio>();
            services.AddTransient<ITipoDocumentoNegocio, TipoDocumentoNegocio>();
            services.AddTransient<ITranstornoMentalNegocio, TranstornoMentalNegocio>();
            services.AddTransient<IMotivaRetroactivaNegocio, MotivaRetroactivaNegocio>();
            services.AddTransient<ICie10Negocio, Cie10Negocio>();
            services.AddTransient<IIncapacidadNegocio, IncapacidadNegocio>();
            services.AddTransient<IRegimenNegocio, RegimenNegocio>();
            services.AddTransient<IMunicipiosNegocio, MunicipiosNegocio>();
            services.AddTransient<IDepartamentosNegocio, DepartamentosNegocio>();
            services.AddTransient<ISexoNegocio, SexoNegocio>();
            services.AddTransient<IPacienteNegocio, PacienteNegocio>();
            services.AddTransient<IPacienteNoEncontradoNegocio, PacienteNoEncontradoNegocio>();
            services.AddTransient<ICausaAnulacionNegocio, CausaAnulacionNegocio>();
            services.AddTransient<IAnulacionNegocio, AnulacionNegocio>();

            services.AddTransient<IRelacionPacienteAfiliacionSaludNegocio, RelacionPacienteAfiliacionSaludNegocio>();
            services.AddTransient<IRelacionPacienteAportanteNegocio, RelacionPacienteAportanteNegocio>();

            services.AddTransient<IModalidadRealizacionConsultaNegocio, ModalidadRealizacionConsultaNegocio>();
            services.AddTransient<IEstadoPagoNegocio, EstadoPagoNegocio>();
            services.AddTransient<ICausalGlosaNegocio, CausalGlosaNegocio>();
            services.AddTransient<ICausalDiasNegocio, CausalDiasNegocio>();
            services.AddTransient<ITipoPagoNegocio, TipoPagoNegocio>();

            services.AddTransient<IConceptoRehabilitacionNegocio, ConceptoRehabilitacionNegocio>();
            services.AddTransient<IConceptoRehabilitacionListNegocio, ConceptoRehabilitacionListNegocio>();

            // Inyectar servicios
            services.AddTransient<IAdministradoraServicio, AdministradoraServicio>();
            services.AddTransient<IGrupoServiciosServicio, GrupoServiciosServicio>();
            services.AddTransient<IOrigenServicio, OrigenServicio>();
            services.AddTransient<ICausaAtencionServicio, CausaAtencionServicio>();
            services.AddTransient<ITipoDocumentoServicio, TipoDocumentoServicio>();
            services.AddTransient<ITranstornoMentalServicio, TranstornoMentalServicio>();
            services.AddTransient<IMotivaRetroactivaServicio, MotivaRetroactivaServicio>();
            services.AddTransient<ICie10Servicio, Cie10Servicio>();
            services.AddTransient<IIncapacidadServicio, IncapacidadServicio>();
            services.AddTransient<IRegimenServicio, RegimenServicio>();
            services.AddTransient<IMunicipiosServicio, MunicipiosServicio>();
            services.AddTransient<IDepartamentosServicio, DepartamentosServicio>();
            services.AddTransient<ISexoServicio, SexoServicio>();
            services.AddTransient<IPacienteServicio, PacienteServicio>();
            services.AddTransient<IPacienteNoEncontradoServicio, PacienteNoEncontradoServicio>();
            services.AddTransient<ICausaAnulacionServicio, CausaAnulacionServicio>();
            services.AddTransient<IAnulacionServicio, AnulacionServicio>();
            services.AddTransient<IGenerarIncapacidadPdfServicio, GenerarIncapacidadPdfServicio>();

            services.AddTransient<IRelacionPacienteAfiliacionSaludServicio, RelacionPacienteAfiliacionSaludServicio>();
            services.AddTransient<IRelacionPacienteAportanteServicio, RelacionPacienteAportanteServicio>();
            services.AddTransient<IModalidadRealizacionConsultaServicio, ModalidadRealizacionConsultaServicio>();

            services.AddTransient<IEstadoPagoServicio, EstadoPagoServicio>();
            services.AddTransient<ICausalGlosaServicio, CausalGlosaServicio>();
            services.AddTransient<ICausalDiasServicio, CausalDiasServicio>();
            services.AddTransient<ITipoPagoServicio, TipoPagoServicio>();

            services.AddTransient<IConceptoRehabilitacionServicio, ConceptoRehabilitacionServicio>();
            services.AddTransient<IConceptoRehabilitacionListServicio, ConceptoRehabilitacionListServicio>();

            return services;
        }
    }
}
