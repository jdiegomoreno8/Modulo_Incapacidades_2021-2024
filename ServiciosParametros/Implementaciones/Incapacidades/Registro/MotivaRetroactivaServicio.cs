using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;


namespace ServiciosParametros.Incapacidades
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
