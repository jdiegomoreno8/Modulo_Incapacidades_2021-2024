using System;
using LibreriasIncapacidades.Modelos;
using WebApiIncapacidades.Modelos;
using ServiciosIncapacidades.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace ServiciosIncapacidades.Implementaciones
{
	public class AutorizacionTokenServicio : IAutorizacionTokenServicio
	{

		private readonly IUsuarioServicio _usuarioServicio;
		private readonly TokenManagement _tokenManagement;

		public AutorizacionTokenServicio(IUsuarioServicio userService, IOptions<TokenManagement> tokenManagement)
		{
			_usuarioServicio = userService;
			_tokenManagement = tokenManagement.Value;
		}
		public bool UsuarioAutenticado(Login datosLogueo, out string Token)
		{
			Token = string.Empty;
			if (!_usuarioServicio.AutorizarToken())
				return false;

			var claims = new[]
			{
				new Claim(ClaimTypes.Name,datosLogueo.NombreUsuario)
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);

			Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

			return true;

		}
	}
}
