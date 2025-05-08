using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
  public interface IRegimenNegocio
    {
        IList<Regimen> Consultar_Todos_Regimen();
    }
}
