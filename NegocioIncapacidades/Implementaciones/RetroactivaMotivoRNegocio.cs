using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
{
    public class RetroactivaMotivoRNegocio : IRetroactivaMotivoRNegocio
    {
        readonly IAccesoDatosReadOnly retroactivamotivorRepositorio;

        public RetroactivaMotivoRNegocio(IAccesoDatosReadOnly retroactivamotivorRepositorioIn)
        {
            retroactivamotivorRepositorio = retroactivamotivorRepositorioIn;
        }
        public IList<MotivaRetroactiva> ObtenerTodosRetroactivaMotivoR()
        {
            return retroactivamotivorRepositorio.Consultar_Motiva_Retroactiva();
        }

    }
}
