using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;

namespace ServiciosIncapacidades
{
    public interface IConsultaPersonaServicio
    {
        public Paciente Consultar(Paciente persona);
    }
}
