using LibreriasIncapacidades.Modelos;

namespace ServiciosIncapacidades
{
    public interface IConsultaSATServicio
    {
        Paciente ConsultarServicioSAT(Paciente pacienteABuscar);

        Paciente ConsultarServicioSATMock(Paciente pacienteABuscar);
    }
}