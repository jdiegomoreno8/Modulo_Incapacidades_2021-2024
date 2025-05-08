using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
  public interface IRegimenNegocio
    {
        IList<Regimen> Consultar_Todos_Regimen();
    }
}
