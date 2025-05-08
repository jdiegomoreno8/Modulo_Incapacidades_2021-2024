using LibreriasIncapacidades.Modelos;
using Microsoft.Extensions.Configuration;
using NegocioIncapacidades;
using System;
using System.IO;

namespace ServiciosIncapacidades
{
    public class ConsultaNacimientosDefuncionesServicio : IConsultaNacimientosDefuncionesServicio
    {
        private static HttpClientHelper<PersonaNacimientosDefunciones[]> ClientND { get; set; }

        public ConsultaNacimientosDefuncionesServicio(IPacienteMaestroPriorizadoNegocio pacienteMaestroPriorizadoNegocioIn)
        {
            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();

            ClientND = new HttpClientHelper<PersonaNacimientosDefunciones[]>(_configuration.GetConnectionString("NacimientosDefuncionesUrl"));
        }  

        public Paciente ConsultarServicioNacimientosDefunciones(Paciente pacienteABuscar)
        {
            Paciente paciente = new Paciente();

            try
            {
                string c = Directory.GetCurrentDirectory();
                IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();

                pacienteABuscar.primer_nombre = (!string.IsNullOrEmpty(pacienteABuscar.primer_nombre) ? pacienteABuscar.primer_nombre : "_");
                pacienteABuscar.primer_apellido = (!string.IsNullOrEmpty(pacienteABuscar.primer_apellido) ? pacienteABuscar.primer_apellido : "_");
                PersonaNacimientosDefunciones[] personaNacimientosDefunciones = /*new PersonaNacimientosDefunciones();//*/
                                        ClientND.GetSingleItemRequest(_configuration.GetConnectionString("NacimientosDefuncionesService") + "/" + pacienteABuscar.tipo_documento + "/" + pacienteABuscar.numero_documento +
                                                 "/" + pacienteABuscar.primer_nombre + "/" + pacienteABuscar.primer_apellido).Result;

                foreach (PersonaNacimientosDefunciones personaND in personaNacimientosDefunciones)
                {
                    if (!string.IsNullOrEmpty(personaND.NumeroCertificadoDefuncion))
                    {
                        paciente.numeroCertificadoDefuncion = personaND.NumeroCertificadoDefuncion;
                    }
                }

            }
            catch (Exception e)
            {
                Console.Write("Error en servicio de nacimientos y defunciones " + e.Message + " - " + e.InnerException);
            }


            return paciente;
            }
    }
}
