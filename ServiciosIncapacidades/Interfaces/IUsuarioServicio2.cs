using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IUsuarioServicio2
    {
        bool IsValid(LoginRequestDTO req);
    }
}
