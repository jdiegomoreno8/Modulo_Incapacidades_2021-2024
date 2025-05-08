using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
   public interface IAdministradoraServicio
    {
        IEnumerable<Administradoras> Consultar_Administradora(string codRegimen, string tipoAdministradora);
    }
}
