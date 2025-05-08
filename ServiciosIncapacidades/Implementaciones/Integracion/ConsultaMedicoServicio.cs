using LibreriasIncapacidades.Modelos;
using Microsoft.Extensions.Configuration;
using NegocioIncapacidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ServiciosIncapacidades
{
    public class ConsultaMedicoServicio : IConsultaMedicoServicio
    {

        private static HttpClientHelper<MedicoRethus> Client { get; set; }

        public ConsultaMedicoServicio()
        {
            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            
            //Descomentar cuando se tenga el Servicio
            //Client = new HttpClientHelper<MedicoRethus>(_configuration.GetConnectionString("RethusService"));
        }

        public Medico ConsultarMedicoRethus(Medico medicoABuscar)
        {
            string stringData = JsonConvert.SerializeObject(new { TipoDocumento = medicoABuscar.tipo_documento, NumeroDocumento = medicoABuscar.numero_documento });
            MedicoRethus medicoRethus = new MedicoRethus("test");
                                    //Client.PostRequest("/", stringData).Result;
            Medico medico = new Medico();


            if (!string.IsNullOrEmpty(medicoRethus.PrimerNombre) 
                //eliminar estos condicionales cuando se tenga el Servicio
                && medicoABuscar.tipo_documento == medicoRethus.TipoDocumento
                && medicoABuscar.numero_documento == medicoRethus.NumeroDocumento
                )
            {
                medico.tipo_documento = medicoRethus.TipoDocumento;
                medico.numero_documento = medicoRethus.NumeroDocumento;
                medico.primer_nombre = medicoRethus.PrimerNombre;
                medico.segundo_nombre = medicoRethus.SegundoNombre;
                medico.primer_apellido = medicoRethus.PrimerApellido;
                medico.segundo_apellido = medicoRethus.SegundoApellido;
                medico.sexo = medicoRethus.Sexo;
                medico.medico_encontrado = medicoRethus.Encontrado;
            }
            //Paciente paciente = new Paciente();
            return medico;
        }
    }
}
