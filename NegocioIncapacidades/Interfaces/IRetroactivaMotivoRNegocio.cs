using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
{
    public interface IRetroactivaMotivoRNegocio
    {
        IList<MotivaRetroactiva> ObtenerTodosRetroactivaMotivoR();

    }
}
