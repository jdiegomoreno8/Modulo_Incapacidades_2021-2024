using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public interface IMotivaRetroactivaNegocio
    {
        IList<MotivaRetroactiva> Consultar_Todos_Motiva_Retroactiva();

    }
}
