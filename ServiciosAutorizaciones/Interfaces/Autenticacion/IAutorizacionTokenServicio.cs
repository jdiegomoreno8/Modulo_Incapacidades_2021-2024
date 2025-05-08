using LibreriasAutorizaciones.Modelos;

namespace ServiciosAutorizaciones.Autenticacion
{
	public interface IAutorizacionTokenServicio
	{
		bool UsuarioAutenticado (Login datosLogueo, out string Token);
	}
}
