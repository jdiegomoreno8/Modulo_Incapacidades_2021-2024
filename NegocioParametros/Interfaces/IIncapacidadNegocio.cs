using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace NegocioParametros
{
    public interface IIncapacidadNegocio
    {
        IList<Incapacidad> ConsultaIncapacidad(Incapacidad incapacidad);

        string NuevaIncapacidad(Incapacidad incapacidad);

        Incapacidad ObtenerTodaIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento);

        IList<string> ConsultaCamposAnulacionIncapacidad(string numeroIncapacidad);

    }
}
