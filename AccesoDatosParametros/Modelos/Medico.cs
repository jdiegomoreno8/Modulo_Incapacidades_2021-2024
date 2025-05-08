using System;

namespace LibreriasParametros.Modelos
{
    public class Medico
    {

        //public Int64 id_paciente { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        //public Boolean paciente_encontrado { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string sexo { get; set; }
        public Boolean medico_encontrado { get; set; }


    }
}
