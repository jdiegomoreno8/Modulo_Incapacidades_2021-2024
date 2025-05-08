using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiIncapacidades.Utility
{
    public static class DataStorage
    {
        public static List<Paciente> GetAllPacientes() => new List<Paciente> {
        new Paciente {tipo_documento="CC", numero_documento="Salud", primer_nombre="Juan",
            segundo_nombre="Carlos"}

        };

    }
}
