using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface IMotivaRetroactivaNegocio
    {
        IList<MotivaRetroactiva> Consultar_Todos_Motiva_Retroactiva();

    }
}
