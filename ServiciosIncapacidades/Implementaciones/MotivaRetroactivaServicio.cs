using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
   public class MotivaRetroactivaServicio : IMotivaRetroactivaServicio
    {
        private readonly IMotivaRetroactivaNegocio MotivaRetroactivaNegocio;
        public MotivaRetroactivaServicio(IMotivaRetroactivaNegocio MotivaRetroactivaNegocioIn)
        {
            MotivaRetroactivaNegocio = MotivaRetroactivaNegocioIn;
        }

        public IEnumerable<MotivaRetroactiva> Consultar_Motiva_Retroactiva()
        {
            var ListaMotivoRetroactiva = MotivaRetroactivaNegocio.Consultar_Todos_Motiva_Retroactiva();
            return ListaMotivoRetroactiva;
        }
    }
}
