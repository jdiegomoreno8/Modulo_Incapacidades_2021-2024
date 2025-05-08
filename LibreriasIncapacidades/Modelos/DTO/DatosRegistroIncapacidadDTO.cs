using LibreriasIncapacidades.Modelos;

namespace WebApiIncapacidades.Modelos.DTO
{
    public class DatosRegistroIncapacidadDTO
    {
        public Incapacidad incapacidad { get; set;  }

        public PacienteNoEncontrado paciente { get; set; }

        //public Aportante aportante { get; set; }
        
    }
}