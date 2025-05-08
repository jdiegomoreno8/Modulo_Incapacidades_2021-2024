using LibreriasIncapacidades.Modelos;
using System;
using LibreriasIncapacidades.Modelos.DTO;
using System.Collections.Generic;


namespace LibreriasIncapacidades.AccesoDatos
{
    public interface IAccesoDatosReadOnly
    {
        public IList<GrupoServicios> Consultar_Grupo_Servicios();
        //public IList<FinalidadConsulta> Consultar_Finalidad_Consulta();

        public IList<ModalidadRealizacionConsulta> Consultar_Modalidad_Realizacion_Consulta();


        public IList<Origen> Consultar_Origen();
        public IList<CausaAtencion> Consultar_Causa_Motivo_Atencion();

        public IList<TipoDocumento> Consultar_Tipo_Documento();

        public IList<TranstornoMental> Consultar_Transtorno_Mental();

        public IList<MotivaRetroactiva> Consultar_Motiva_Retroactiva();

        public IList<Cie10> ConsultaCie10();


        public IList<Cie10> ConsultaCie10(string value);

        public IList<Municipios> Consultar_Municipios();

        public IList<Regimen> Consultar_Regimen();

        public IList<Sexo> Consultar_Sexo();

        public IList<EstadoPago> Consultar_Estado_Pago();
        public IList<CausalGlosa> Consultar_Causal_Glosa();


        public IList<Departamentos> Consultar_Departamentos();



        public IList<Incapacidad> Consultar_Incapacidad_Por_Paciente(Incapacidad incapacidad);



        public Incapacidad ConsultaIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento);

        public Incapacidad Consultar_Incapacidad(string id_incapacidad);

        public IList<CausaAnulacion> Consultar_Causa_Anulacion();
        public IList<TipoPago> Consultar_Tipo_Pago();
        public IList<CausalDias> Consultar_Causal_Dias();



        public IList<Administradoras> Consultar_Administradora(string codRegimen, string tipoAdministradora);


        IList<string> Consultar_Campos_Anulacion(string numeroIncapacidad);

        Paciente ObtenerPaciente(string IdTipoDocumento, string NumeroDocumento, string numeroIncapacidad);

        PacienteNoEncontrado ObtenerPacienteNoEncontrado(string IdTipoDocumento, string NumeroDocumento);

        RelacionPacienteAfiliacionSalud Consultar_RelacionPacienteAfiliacionSalud(long idPaciente);
        public string Consultar_Incapacidad_Registrar_Pago(ConsultarRegistroPago consultarRegistroPago);

        public IList<Incapacidad> Consultar_Incapacidad_Concepto_Rehabilitacion(Paciente paciente);

        public IList<Concepto_Rehabilitacion> Consultar_Concepto_Rehabilitacion();

        public RegistroConceptoRehabilitacion Consultar_Concepto_Rehabilitacion_Por_Paciente(Paciente pacienteCR);

        public IList<RelacionPacienteAportante> Consultar_RelacionPacienteAportante(string id_incapacidad);
        public IList<PerdidaCapacidadLaboral> Consultar_PerdidaCapacidadLaboral(Int64 id_concepto_registro);
       
        public IList<RegistroConceptoRehabilitacion> Consultar_TodosListasConsultarConceptos(Paciente pacienteCR);


        IList<NotificarIncapacidadDTO> Consultar_Notificar_Incapacidad(NotificarIncapacidadDTO incapacidad);

        IList<NotificarIncapacidadDTO> Consultar_Notificar_Incapacidad_180_540(NotificarIncapacidadDTO incapacidad);

        IList<NotificarIncapacidadDTO> GetNotificar_IncapacidadAnulada(NotificarIncapacidadDTO incapacidad);

        IList<NotificarIncapacidadDTO> GetNotificar_IncapacidadARehabilitacion(NotificarIncapacidadDTO incapacidad);

        IList<RegistroConceptoRehabilitacion> GetIncapacidadARehabilitacion(Incapacidad incapacidad);

        IList<NotificarIncapacidadPagadaDTO> Consultar_Notificar_Incapacidad_Pagada(NotificarIncapacidadPagadaDTO incapacidad);

        IList<RegistrarPago> Consultar_Incapacidad_Pagada(RegistrarPago registroPago);
    }
}
