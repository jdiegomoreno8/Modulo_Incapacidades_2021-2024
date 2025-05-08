using LibreriasParametros.Modelos;
using System.Collections.Generic;
using LibreriasParametros.Modelos.DTO;

namespace ServiciosParametros
{
    public interface IIncapacidadServicio
    {
        Incapacidad AdicionarIncapacidad(Incapacidad incapacidades);
        Incapacidad AdicionarIncapacidadDatosAdicionales(DatosRegistroIncapacidadDTO incapacidades);
        IList<Incapacidad> ConsultarIncapacidad(Incapacidad incapacidad);
        Incapacidad ObtenerIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento);
        IList<string> ObtenerCamposAnulacionIncapacidad(string numeroIncapacidad);

    }
}
