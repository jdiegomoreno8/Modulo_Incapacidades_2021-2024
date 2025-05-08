using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades
{
    public interface IIncapacidadServicio
    {
        Incapacidad AdicionarIncapacidad(Incapacidad incapacidades);
        Incapacidad AdicionarIncapacidadDatosAdicionales(DatosRegistroIncapacidadDTO incapacidades);
        IList<Incapacidad> ConsultarIncapacidad(Incapacidad incapacidad);
        Incapacidad ObtenerIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento);
        IList<string> ObtenerCamposAnulacionIncapacidad(string numeroIncapacidad);
        RespuestBD ObtenerSecuenciaPorCodigo(string codigo);

    }
}
