using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public interface IOrigenNegocio
    {
        IList<Origen> Consultar_Todos_Origen();

    }
}
