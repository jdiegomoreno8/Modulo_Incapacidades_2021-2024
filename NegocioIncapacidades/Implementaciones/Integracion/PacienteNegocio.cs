using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;

namespace NegocioIncapacidades
{
   public class PacienteMaestroPriorizadoNegocio : IPacienteMaestroPriorizadoNegocio
    {
        readonly IAccesoDatosMaestroPriorizado pacienteMaestroPriorizadoRepositorio;

        public PacienteMaestroPriorizadoNegocio(IAccesoDatosMaestroPriorizado pacienteMaestroPriorizadoRepositorioIn)
        {
            pacienteMaestroPriorizadoRepositorio = pacienteMaestroPriorizadoRepositorioIn;
        }

        public MaestroPriorizado ConsultarPacienteMaestroPriorizado(Paciente paciente)
        {
            return pacienteMaestroPriorizadoRepositorio.Consultar_Datos_Paciente(paciente);
        }

    }
}
