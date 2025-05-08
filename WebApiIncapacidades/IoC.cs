using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Negocio;
using NegocioIncapacidades;
using NegocioIncapacidades.Implementaciones;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades;
using ServiciosIncapacidades.Implementaciones;
using ServiciosIncapacidades.Interfaces;

namespace WebApiIncapacidades
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
            services.AddTransient<IAccesoDatosReadOnlyAdmin, AccesoDatosReadOnlyAdmin>();
            services.AddTransient<IAccesoDatosDataWriteAdmin, AccesoDatosDataWriteAdmin>();
            services.AddTransient<IAccesoDatosMaestroPriorizado, AccesoDatosMaestroPriorizado>();

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
            services.AddTransient<IPacienteMaestroPriorizadoNegocio, PacienteMaestroPriorizadoNegocio>();

            services.AddTransient<IRelacionPacienteAfiliacionSaludNegocio, RelacionPacienteAfiliacionSaludNegocio>();
            services.AddTransient<IRelacionPacienteAportanteNegocio, RelacionPacienteAportanteNegocio>();

            //services.AddTransient<IAutenticarNegocio, AutenticarNegocio>();
            //services.AddTransient<ITraerFuncionalidadesNegocio, TraerFuncionalidadesNegocio>();

            services.AddTransient<IModalidadRealizacionConsultaNegocio, ModalidadRealizacionConsultaNegocio>();
            services.AddTransient<IEstadoPagoNegocio, EstadoPagoNegocio>();
            services.AddTransient<ICausalGlosaNegocio, CausalGlosaNegocio>();
            services.AddTransient<IRegistrarPagoNegocio, RegistrarPagoNegocio>();
            services.AddTransient<IConsultarRegistroPagoNegocio, ConsultarRegistroPagoNegocio>();
            services.AddTransient<ICausalDiasNegocio, CausalDiasNegocio>();
            services.AddTransient<ITipoPagoNegocio, TipoPagoNegocio>();

            services.AddTransient<IConceptoRehabilitacionNegocio, ConceptoRehabilitacionNegocio>();
            services.AddTransient<IConceptoRehabilitacionListNegocio, ConceptoRehabilitacionListNegocio>();
            
            // Notifications
            services.AddTransient<IExpedirIncapacidadProducerNegocio, ExpedirIncapacidadProducerNegocio>();
            services.AddTransient<IAnularIncapacidadProducerNegocio, AnularIncapacidadProducerNegocio>();
            services.AddTransient<IPagarIncapacidadProducerNegocio, PagarIncapacidadProducerNegocio>();
            services.AddTransient<IVerificarConceptoRehabilitacionProducerNegocio, VerificarConceptoRehabilitacionProducerNegocio>();

            services.AddTransient<IPerdidaCapacidadLaboralNegocio, PerdidaCapacidadLaboralNegocio>();
            services.AddTransient<IConsultaConceptoRehabilitacionNegocio, ConsultaConceptoRehabilitacionNegocio>();
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
            services.AddTransient<IConsultaPersonaServicio, ConsultaPersonaServicio>();
            services.AddTransient<IConsultaSATServicio, ConsultaSATServicio>();
            services.AddTransient<IGenerarIncapacidadPdfServicio, GenerarIncapacidadPdfServicio>();
            services.AddTransient<IConsultaMaestroPriorizadoServicio, ConsultaMaestroPriorizadoServicio>();
            services.AddTransient<IConsultaNacimientosDefuncionesServicio, ConsultaNacimientosDefuncionesServicio>();

            services.AddTransient<IRelacionPacienteAfiliacionSaludServicio, RelacionPacienteAfiliacionSaludServicio>();
            services.AddTransient<IRelacionPacienteAportanteServicio, RelacionPacienteAportanteServicio>();
            services.AddTransient<IModalidadRealizacionConsultaServicio, ModalidadRealizacionConsultaServicio>();

            //services.AddTransient<IAutorizacionTokenServicio, AutorizacionTokenServicio>();
            //services.AddTransient<ICargarMenuServicio, CargarMenuServicio>();
            //services.AddTransient<IUsuarioServicio, UsuarioAutenticadoServicio>();

            services.AddTransient<IConsultaSATServicio, ConsultaSATServicio>();
            services.AddTransient<IEstadoPagoServicio, EstadoPagoServicio>();
            services.AddTransient<ICausalGlosaServicio, CausalGlosaServicio>();
            services.AddTransient<IRegistrarPagoServicio, RegistrarPagoServicio>();
            services.AddTransient<IConsultarRegistroPagoServicio, ConsultaRegistroPagoServicio>();
            services.AddTransient<ICausalDiasServicio, CausalDiasServicio>();
            services.AddTransient<ITipoPagoServicio, TipoPagoServicio>();

            services.AddTransient<IConceptoRehabilitacionServicio, ConceptoRehabilitacionServicio>();
            services.AddTransient<IConceptoRehabilitacionListServicio, ConceptoRehabilitacionListServicio>();
            services.AddTransient<IConsultaMedicoServicio, ConsultaMedicoServicio>();
            services.AddTransient<IPerdidaCapacidadLaboralServicio, PerdidaCapacidadLaboralServicio>();
            services.AddTransient<IConsultaConceptoRehabilitacionServicio, ConsultaConceptoRehabilitacionServicio>();


            return services;
        }
    }
}
