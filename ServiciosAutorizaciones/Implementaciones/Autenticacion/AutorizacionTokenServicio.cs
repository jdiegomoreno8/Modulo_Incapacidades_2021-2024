using System;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using LibreriasAutorizaciones.Modelos.DTO;
using LibreriasAutorizaciones.Modelos;
using Microsoft.Extensions.Configuration;

namespace ServiciosAutorizaciones.Autenticacion
{
	public class AutorizacionTokenServicio : IAutorizacionTokenServicio
	{

		private readonly IUsuarioAutenticadoServicio _usuarioServicio;
        //private readonly TokenManagement _tokenManagement;
        public IConfiguration _configuration;

        public AutorizacionTokenServicio(IUsuarioAutenticadoServicio userService, IConfiguration _configuration/*, IOptions<TokenManagement> tokenManagement*/)
		{
			_usuarioServicio = userService;
            this._configuration = _configuration;
            //_tokenManagement = tokenManagement.Value;
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
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Security"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var jwtToken = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], claims, expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JWT:AccessTokenExpireTime"])), signingCredentials: credentials);

			Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

			return true;

		}
	}
}
