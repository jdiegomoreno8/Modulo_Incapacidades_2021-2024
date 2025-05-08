using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace WebApiParametros.Utility
{
    public static class DataStorage
    {
        public static List<Paciente> GetAllPacientes() => new List<Paciente> {
        new Paciente {tipo_documento="CC", numero_documento="Salud", primer_nombre="Juan",
            segundo_nombre="Carlos"}

        };

    }
}
