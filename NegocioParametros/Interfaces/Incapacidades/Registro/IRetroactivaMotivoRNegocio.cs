using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface IRetroactivaMotivoRNegocio
    {
        IList<MotivaRetroactiva> ObtenerTodosRetroactivaMotivoR();

    }
}
