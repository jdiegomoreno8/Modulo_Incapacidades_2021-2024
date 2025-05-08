using System;
using LibreriasIncapacidades.Modelos;

namespace ServiciosIncapacidades.Interfaces
{
	public interface IAutorizacionTokenServicio
	{
		bool UsuarioAutenticado (Login datosLogueo, out string Token);
	}
}
