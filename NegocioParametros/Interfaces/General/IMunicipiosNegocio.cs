using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
  public interface IMunicipiosNegocio
    {
        IList<Municipios> Consultar_Todos_Municipios();
    }
}
