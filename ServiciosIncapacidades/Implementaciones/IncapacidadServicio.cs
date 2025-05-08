using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.DTO;
using Microsoft.Extensions.Configuration;
using NegocioIncapacidades;
using NegocioIncapacidades.Implementaciones;
using ServiciosUtils;
using System;
using System.Collections.Generic;
using System.Globalization;
using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades
{
    public class IncapacidadServicio : IIncapacidadServicio
    {
        private readonly IConfiguration configuration;
        private readonly IIncapacidadNegocio incapacidadNegocio;
        private readonly IPacienteNegocio pacienteNegocio;
        private readonly IPacienteNoEncontradoNegocio pacienteNoEncontradoNegocio;
        private readonly IRelacionPacienteAportanteNegocio relacionPacienteAportanteNegocio;
        private readonly IRelacionPacienteAfiliacionSaludNegocio relacionPacienteAfiliacionSaludNegocio;
        private readonly IExpedirIncapacidadProducerNegocio expedirIncapacidadProducerNegocio;
        private readonly IVerificarConceptoRehabilitacionProducerNegocio verificarConceptoRehabilitacion;

        public IncapacidadServicio(IConfiguration configurationIn, IIncapacidadNegocio incapacidadNegocioIn, IPacienteNegocio pacienteNegocioIn, IPacienteNoEncontradoNegocio pacienteNoEncontradoNegocioIn,
            IRelacionPacienteAportanteNegocio relacionPacienteAportanteNegocioIn, IRelacionPacienteAfiliacionSaludNegocio relacionPacienteAfiliacionSaludNegocioIn, IExpedirIncapacidadProducerNegocio expedirIncapacidadProducerNegocioIn,
            IVerificarConceptoRehabilitacionProducerNegocio verificarConceptoRehabilitacionIn)
        {
            configuration = configurationIn;
            incapacidadNegocio = incapacidadNegocioIn;
            pacienteNegocio = pacienteNegocioIn;
            pacienteNoEncontradoNegocio = pacienteNoEncontradoNegocioIn;
            relacionPacienteAportanteNegocio = relacionPacienteAportanteNegocioIn;
            relacionPacienteAfiliacionSaludNegocio = relacionPacienteAfiliacionSaludNegocioIn;
            expedirIncapacidadProducerNegocio = expedirIncapacidadProducerNegocioIn;
            verificarConceptoRehabilitacion = verificarConceptoRehabilitacionIn;
        }

        public Incapacidad AdicionarIncapacidad(Incapacidad incapacidad)
        {
            incapacidad.id_incapacidad = incapacidadNegocio.NuevaIncapacidad(incapacidad);
            return incapacidad;
        }

        public Incapacidad AdicionarIncapacidadDatosAdicionales(DatosRegistroIncapacidadDTO data)
        {
            DateTime validacionfechaActual = DateTime.Now;

            data.incapacidad.fecha_expedicion = DateTime.ParseExact(data.incapacidad.fecha_expedicion_string, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            int esFechaValida = data.incapacidad.fecha_expedicion.Value.ToString("MM/dd/yyyy")
                     .CompareTo(validacionfechaActual.ToString("MM/dd/yyyy"));

            if(esFechaValida != 0)
            {
                throw new AppException("La fecha de expedición de la incapacidad no coincide con la fecha del sistema");
            }

            data.incapacidad.fecha_expedicion = DateTime.Now;

            var fechaNacimiento = DateTime.ParseExact(data.paciente.fecha_nacimiento_string, "yyyy-MM-dd", CultureInfo.InvariantCulture);//data.paciente.fecha_nacimiento_string; //
            data.incapacidad.edad_pac = CalcularEdad(fechaNacimiento);

            if (data.incapacidad.paciente_encontrado)
            {
                data.paciente.id_paciente = Int64.Parse(pacienteNegocio.NuevoPaciente(data.paciente));
            }
            else if (data.incapacidad.proviene_anulado != true)
            {
                pacienteNoEncontradoNegocio.NuevoPacienteNoEncontrado(data.paciente);
            }

            if (data.paciente.aportantes != null)
            {
                foreach (Aportante nuevoAportante in data.paciente.aportantes)
                {
                    //if (data.paciente.aportanteSeleccionado != null)
                    //{
                    //    pacienteNegocio.NuevoAportante(data.paciente.aportanteSeleccionado);
                    //}
                    pacienteNegocio.NuevoAportante(nuevoAportante);
                }    
            }

            data.incapacidad.id_incapacidad = incapacidadNegocio.NuevaIncapacidad(data.incapacidad);


            if (data.paciente.relacionesPacienteAportante != null)
            {
            foreach (RelacionPacienteAportante nuevaRelacionPacienteAportante in data.paciente.relacionesPacienteAportante)
            {
                if (data.paciente.relacionPacienteAportanteSeleccionada != null)
                {
                    if (nuevaRelacionPacienteAportante.tipo_documento_ap.Equals(data.paciente.relacionPacienteAportanteSeleccionada.tipo_documento_ap)
                        && nuevaRelacionPacienteAportante.numero_documento_ap.Equals(data.paciente.relacionPacienteAportanteSeleccionada.numero_documento_ap))
                    {
                        nuevaRelacionPacienteAportante.relacion_causa_incapacidad = true;
                    }
                }
                nuevaRelacionPacienteAportante.id_incapacidad = data.incapacidad.id_incapacidad;
                relacionPacienteAportanteNegocio.NuevoRelacionPacienteAportante(nuevaRelacionPacienteAportante);
                //data.paciente.relacionPacienteAportanteSeleccionada.id_incapacidad = data.incapacidad.id_incapacidad;
                //relacionPacienteAportanteNegocio.NuevoRelacionPacienteAportante(data.paciente.relacionPacienteAportanteSeleccionada);
            }
            }

            if (data.incapacidad.paciente_encontrado && data.paciente.relacionPacienteAfiliacionSalud != null)
            {   
                data.paciente.relacionPacienteAfiliacionSalud.id_incapacidad = data.incapacidad.id_incapacidad;
                data.paciente.relacionPacienteAfiliacionSalud.id_paciente = data.paciente.id_paciente;
                relacionPacienteAfiliacionSaludNegocio.NuevoRelacionPacienteAfiliacionSalud(data.paciente.relacionPacienteAfiliacionSalud);
            }

            //Enviar notificación
            try
            {
                if (configuration["Settings:ActiveNotifications"] == "true")
                {
                    NotificarIncapacidadDTO notificacion = new NotificarIncapacidadDTO
                    {
                        id_incapacidad = data.incapacidad.id_incapacidad,
                        id_origen = data.incapacidad.id_origen,
                        paciente_encontrado = data.incapacidad.paciente_encontrado,
                        dias_acumulados_prorroga = data.incapacidad.dias_acumulados_prorroga
                    };

                    expedirIncapacidadProducerNegocio.SendNotificationIncapacidadMessage(notificacion);

                    if (data.incapacidad.dias_acumulados_prorroga > 90)
                    {
                        if (data.paciente.id_regimen != "S")
                        {
                            verificarConceptoRehabilitacion.SendNotificationIncapacidadMessage(notificacion);
                        }
                    }else if(data.incapacidad.dias_acumulados_prorroga >= 120 && data.incapacidad.dias_acumulados_prorroga <= 150)
                    {
                        if (data.paciente.id_regimen != "S" && data.incapacidad.id_origen == 1)//comun
                        {
                            verificarConceptoRehabilitacion.SendNotificationIncapacidadMessage(notificacion);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                var resultObjectLog = new { codigo = "501", mensaje = e.Message, detalle = e.InnerException != null ? e.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty, data = "Error creando notificacion de expedición" };
                LogFileService.Write(resultObjectLog.ToString());
            }

            return data.incapacidad;

            //todo
            //crear un catch anulando los registros creados asociados a la incapacidad
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int edad = now.Year - fechaNacimiento.Year;
            if (now < fechaNacimiento.AddYears(edad))
            {
                edad--;
            }
            return edad;
        }

        public IList<Incapacidad> ConsultarIncapacidad(Incapacidad incapacidad)
        {
            return incapacidadNegocio.ConsultaIncapacidad(incapacidad);
        }
        public Incapacidad ObtenerIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento)
        {
            var incapacidad = incapacidadNegocio.ObtenerTodaIncapacidad(numeroIncapacidad, tipoDocumento, numeroDocumento);
            return incapacidad;
        }

        public IList<string> ObtenerCamposAnulacionIncapacidad(string numeroIncapacidad)
        {
            var camposAnulacion = incapacidadNegocio.ConsultaCamposAnulacionIncapacidad(numeroIncapacidad);
            return camposAnulacion;
        }

        public RespuestBD ObtenerSecuenciaPorCodigo(string codigo)
        {
            return incapacidadNegocio.ObtenerSecuenciaPorCodigo(codigo);
        }
    }
}
