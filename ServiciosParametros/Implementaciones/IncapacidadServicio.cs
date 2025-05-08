using LibreriasParametros.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using LibreriasParametros.Modelos.DTO;
using NegocioParametros;

namespace ServiciosParametros
{
    public class IncapacidadServicio : IIncapacidadServicio
    {
        private readonly IIncapacidadNegocio incapacidadNegocio;
        private readonly IPacienteNegocio pacienteNegocio;
        private readonly IPacienteNoEncontradoNegocio pacienteNoEncontradoNegocio;
        private readonly IRelacionPacienteAportanteNegocio relacionPacienteAportanteNegocio;
        private readonly IRelacionPacienteAfiliacionSaludNegocio relacionPacienteAfiliacionSaludNegocio;

        public IncapacidadServicio(IIncapacidadNegocio IncapacidadNegocioIn, IPacienteNegocio pacienteNegocioIn, IPacienteNoEncontradoNegocio pacienteNoEncontradoNegocioIn,
            IRelacionPacienteAportanteNegocio relacionPacienteAportanteNegocioIn, IRelacionPacienteAfiliacionSaludNegocio relacionPacienteAfiliacionSaludNegocioIn)
        {
            incapacidadNegocio = IncapacidadNegocioIn;
            pacienteNegocio = pacienteNegocioIn;
            pacienteNoEncontradoNegocio = pacienteNoEncontradoNegocioIn;
            relacionPacienteAportanteNegocio = relacionPacienteAportanteNegocioIn;
            relacionPacienteAfiliacionSaludNegocio = relacionPacienteAfiliacionSaludNegocioIn;
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

            if (data.paciente.aportanteSeleccionado != null && data.paciente.aportanteSeleccionado?.numero_documento!= "")
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


            if (data.paciente.relacionPacienteAportanteSeleccionada != null && data.paciente.relacionPacienteAportanteSeleccionada?.numero_documento_ap != "")
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

            return data.incapacidad;

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
    }
}
