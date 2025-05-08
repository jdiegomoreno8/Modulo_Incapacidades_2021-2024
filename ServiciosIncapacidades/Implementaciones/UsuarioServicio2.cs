using ServiciosIncapacidades.Interfaces;
using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades.Implementaciones
{
    public class UsuarioServicio2 : IUsuarioServicio2
    {
        // Prueba de simulación, el valor predeterminado es verificación artificial efectiva
        public bool IsValid(LoginRequestDTO req)
        {
            return true;
        }
    }
}
