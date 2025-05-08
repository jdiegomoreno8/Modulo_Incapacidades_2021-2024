using LibreriasParametros.Modelos;
using NegocioParametros;

namespace ServiciosParametros
{
    public class AnulacionServicio : IAnulacionServicio
    {
        private readonly IAnulacionNegocio AnulacionNegocio;
        public AnulacionServicio(IAnulacionNegocio AnulacionNegocioIn)
        {
            AnulacionNegocio = AnulacionNegocioIn;
        }

        public int AnularIncapacidad(IncapacidadAnulada incapacidadAnulada)
        {
            int anulada = AnulacionNegocio.AnularIncapacidad(incapacidadAnulada);
            return anulada;
        }
    }
}
