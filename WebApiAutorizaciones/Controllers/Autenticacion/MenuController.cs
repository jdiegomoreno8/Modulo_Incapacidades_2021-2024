using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System;
using LibreriasAutorizaciones.Modelos;
using System.Collections.Generic;
using LibreriasAutorizaciones.Modelos.DTO;
using ServiciosAutorizaciones.Autenticacion;

namespace WebApiIncapacidades.Controllers
{
	[ApiController]
	public class MenuController : Controller
	{
		private List<Funcionalidad> funcionalidades;
		
		private readonly ICargarMenuServicio _cargarMenu;
		
		public MenuController(ICargarMenuServicio objetoCargarMenu)
		{
			this._cargarMenu = objetoCargarMenu;
		}

		[Route("api/[controller]/CargarMenu")]
		[HttpPost]
		public ActionResult CargarMenu(Perfil idRol)
	
		{
			funcionalidades = _cargarMenu.TraerFuncionalidades(idRol.idRol);

			//return Ok(funcionalidades[0]);

			string j = JsonConvert.SerializeObject(funcionalidades);
			return Content(j.ToString(), "application/json", Encoding.UTF8);


		}

		[Route("api/[controller]/BuscarUsuario")]
		[HttpPost]
		public ActionResult BuscarIDUsuario(Perfil perfil)

			{
			List<PerfilComple> IDUsuario;
			IDUsuario = _cargarMenu.TraerIDPerfil(perfil);

			return Ok(IDUsuario);

		}

	}

}
