using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;
using System.Globalization;
using WebApiIncapacidades.Modelos.DTO;

namespace NegocioIncapacidades
{
    public class IncapacidadNegocio : IIncapacidadNegocio
    {
        readonly IAccesoDatosDataWrite incapacidadesrepositorioEscritura;
        readonly IAccesoDatosReadOnly incapacidadesRepositorioLectura;

        public IncapacidadNegocio(IAccesoDatosDataWrite incapacidadesrepositorioEscrituraIn, IAccesoDatosReadOnly incapacidadesRepositorioLecturaIn)
        {
            incapacidadesrepositorioEscritura = incapacidadesrepositorioEscrituraIn;
            incapacidadesRepositorioLectura = incapacidadesRepositorioLecturaIn;
        }

        public Incapacidad ObtenerIncapacidad(string id_incapacidad)
        {
            return incapacidadesRepositorioLectura.Consultar_Incapacidad(id_incapacidad);
        }

        public IList<Incapacidad> ConsultaIncapacidad(Incapacidad incapacidad)
        {
            var lista = incapacidadesRepositorioLectura.Consultar_Incapacidad_Por_Paciente(incapacidad);
            foreach (var elemento in lista)
            {
                elemento.fecha_inicio_string = elemento.fecha_inicio.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                elemento.fecha_fin_string = elemento.fecha_fin.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            return lista;
        }

        public string NuevaIncapacidad(Incapacidad incapacidad)
        {

            if (incapacidad.id_incapacidad_anulado == "" || incapacidad.id_incapacidad_anulado == null)
            {
                incapacidad.proviene_anulado = false;
            }
            else
            {
                incapacidad.proviene_anulado = true;
            }

            return incapacidadesrepositorioEscritura.InsertarIncapacidad(incapacidad).resultado;
        }

        public Incapacidad ObtenerTodaIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento)
        {
            tipoDocumento = tipoDocumento ?? "";
            numeroDocumento = numeroDocumento ?? "";
            var incapacidad = incapacidadesRepositorioLectura.ConsultaIncapacidad(numeroIncapacidad, tipoDocumento, numeroDocumento);

            //if (incapacidad == null)
            //{
            //    throw new System.Exception("Incapacidad no encontrada");
            //}
            if (incapacidad != null)
            {
                incapacidad.fecha_inicio_string = incapacidad.fecha_inicio.HasValue ? incapacidad.fecha_inicio.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : "";
                incapacidad.fecha_fin_string = incapacidad.fecha_fin.HasValue ? incapacidad.fecha_fin.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : "";
                incapacidad.fecha_expedicion_string = incapacidad.fecha_expedicion.HasValue ? incapacidad.fecha_expedicion.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) : "";
                if (incapacidad.NotificacionRadicacion != null)
                    incapacidad.NotificacionRadicacion.fecha_notificacion_string = incapacidad.NotificacionRadicacion != null ? incapacidad.NotificacionRadicacion.fecha_notificacion.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : "";
            }

            return incapacidad;
        }

        public IList<string> ConsultaCamposAnulacionIncapacidad(string numeroIncapacidad)
        {
            var lista = incapacidadesRepositorioLectura.Consultar_Campos_Anulacion(numeroIncapacidad);
            return lista;
        }

        public RespuestBD ObtenerSecuenciaPorCodigo(string codigo)
        {
            var resp = incapacidadesrepositorioEscritura.ObtenerSecuenciaPorCodigo(codigo);
            return resp;
        }
    }
}
