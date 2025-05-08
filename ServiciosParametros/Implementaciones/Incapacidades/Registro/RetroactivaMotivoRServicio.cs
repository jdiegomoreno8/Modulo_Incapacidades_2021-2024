using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;


namespace ServiciosParametros.Incapacidades
{
    public class RetroactivaMotivoRServicio : IRetroactivaMotivoRServicio
    {
        private readonly IRetroactivaMotivoRNegocio retroactivaMotivoRNegocio;
        public RetroactivaMotivoRServicio(IRetroactivaMotivoRNegocio MotivaRetroactivaNegocioIn)
        {
            retroactivaMotivoRNegocio = MotivaRetroactivaNegocioIn;
        }
        public IEnumerable<MotivaRetroactiva> ObtenerRetroactivaMotivoR()
        {
            var ListaRetroactivaMotivoR = retroactivaMotivoRNegocio.ObtenerTodosRetroactivaMotivoR();
            return ListaRetroactivaMotivoR;
        }

    }
}
