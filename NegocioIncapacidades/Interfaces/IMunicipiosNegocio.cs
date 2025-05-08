using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
  public interface IMunicipiosNegocio
    {
        IList<Municipios> Consultar_Todos_Municipios();
    }
}
