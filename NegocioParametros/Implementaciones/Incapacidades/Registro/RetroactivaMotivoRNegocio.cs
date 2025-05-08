using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return retroactivamotivorRepositorio.Consultar_Motiva_Retroactiva();
            return (IList<MotivaRetroactiva>) retroactivamotivorRepositorio.Consultar_Motiva_Retroactiva();
        }

    }
}
