using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface IRetroactivaMotivoRServicio
    {
        public IEnumerable<MotivaRetroactiva> ObtenerRetroactivaMotivoR();
    }
}
