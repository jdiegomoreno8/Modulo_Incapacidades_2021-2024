using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using WebApiIncapacidades.Modelos.DTO;

namespace NegocioIncapacidades
{
    public interface IIncapacidadNegocio
    {
        IList<Incapacidad> ConsultaIncapacidad(Incapacidad incapacidad);

        string NuevaIncapacidad(Incapacidad incapacidad);

        Incapacidad ObtenerTodaIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento);

        IList<string> ConsultaCamposAnulacionIncapacidad(string numeroIncapacidad);

        RespuestBD ObtenerSecuenciaPorCodigo(string codigo);
        Incapacidad ObtenerIncapacidad(string id_incapacidad);

    }
}
