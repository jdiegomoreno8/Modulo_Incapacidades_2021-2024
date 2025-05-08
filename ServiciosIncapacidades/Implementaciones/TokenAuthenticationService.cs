using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiIncapacidades.Modelos;
using WebApiIncapacidades.Modelos.DTO;

namespace ServiciosIncapacidades.Implementaciones
{
    public class TokenAuthenticationService : IAutorizacionTokenServicio
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly TokenManagement _tokenManagement;
        public TokenAuthenticationService(IUsuarioServicio userService, IOptions<TokenManagement> tokenManagement)
        {
            _usuarioServicio = userService;
            _tokenManagement = tokenManagement.Value;
        }
        public bool IsAuthenticated(LoginRequestDTO request, out string token)
        {
            token = string.Empty;
            if (!_usuarioServicio.IsValid(request))
                return false;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);

            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return true;

        }
    }
}
