using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public interface IDepartamentosNegocio
    {
        IList<Departamentos> Consultar_Todos_Departamentos();
    }
}
