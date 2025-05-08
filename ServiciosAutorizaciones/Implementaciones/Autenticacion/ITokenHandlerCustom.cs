using System.Security.Claims;

namespace ServiciosAutorizaciones.Implementaciones.Autenticacion
{
    public interface ITokenHandlerCustom
    {
        bool CreateAccessToken(string nameUser, out string token);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);


    }
}