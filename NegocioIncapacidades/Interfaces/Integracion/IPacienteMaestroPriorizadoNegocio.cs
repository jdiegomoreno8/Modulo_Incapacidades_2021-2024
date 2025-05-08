using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;

namespace NegocioIncapacidades
{
    public interface IPacienteMaestroPriorizadoNegocio
    {
        MaestroPriorizado ConsultarPacienteMaestroPriorizado(Paciente paciente);
    }
}
