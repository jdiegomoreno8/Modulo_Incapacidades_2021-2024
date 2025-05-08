using LibreriasIncapacidades.Modelos;

namespace ServiciosIncapacidades
{
    public interface IConsultaMaestroPriorizadoServicio
    {
        Paciente ConsultarPacienteMaestroPriorizado(Paciente paciente);
    }
}