using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos.Integracion
{
    public class RespuestaConsulta
    {
        public string msg { get; set; }
        public bool Success { get; set; }
        public string[] Errors { get; set; }

        public InfoAfiliadoSal InfoAfiliadoSal { get; set; }
        
    }
}
