using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public interface ISexoNegocio
    {
        IList<Sexo> Consultar_Todos_Sexo();
    }
}
