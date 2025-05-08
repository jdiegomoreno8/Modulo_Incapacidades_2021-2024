using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.DTO;
using System.Threading.Tasks;

namespace NegocioIncapacidades.Interfaces
{
    public interface INotificacionIncapacidadNegocio
    {
        Task NotificacionExpedicionIncapacidad(NotificarIncapacidadDTO notifacion, string templateAdministradora, string templateEmpleador, string templateAFP);
        Task NotificacionIncapacidadAnulada(NotificarIncapacidadDTO notificacion, string templateAdministradora, string templateEmpleador, string templateAFP);

        Task NotificacionRegistroConceptoRehabilitacionIncapacidad(NotificarIncapacidadDTO notificacion, string template90, string template120);

        Task NotificacionIncapacidadPagada(NotificarIncapacidadPagadaDTO notificacion, string template);
    }
}
