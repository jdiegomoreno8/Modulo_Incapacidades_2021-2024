using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface IGrupoServiciosServicio
    {
        public IEnumerable<GrupoServicios> Consultar_Grupo_Servicios();
    }
}
