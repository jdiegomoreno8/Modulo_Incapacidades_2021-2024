using LibreriasIncapacidades.Modelos;

namespace ServiciosIncapacidades
{
    public interface IAnulacionServicio
    {
        public int AnularIncapacidad(IncapacidadAnulada incapacidadAnulada);

        //public Incapacidades ObtenerIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento);
    }
}
