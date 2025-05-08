using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
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
