using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;

namespace LibreriasIncapacidades.AccesoDatos
{
    public interface IAccesoDatosMaestroPriorizado
    {
        MaestroPriorizado Consultar_Datos_Paciente(Paciente paciente);
    }
}
