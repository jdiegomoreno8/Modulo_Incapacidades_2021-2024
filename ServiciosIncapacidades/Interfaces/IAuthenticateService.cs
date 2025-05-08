using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(LoginRequestDTO request, out string token);
    }
}
