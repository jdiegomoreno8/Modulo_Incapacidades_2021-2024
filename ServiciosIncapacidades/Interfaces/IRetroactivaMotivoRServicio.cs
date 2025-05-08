using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface IRetroactivaMotivoRServicio
    {
        public IEnumerable<MotivaRetroactiva> ObtenerRetroactivaMotivoR();
    }
}
