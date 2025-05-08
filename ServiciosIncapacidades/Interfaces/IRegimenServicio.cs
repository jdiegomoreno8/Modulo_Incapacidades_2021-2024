using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IRegimenServicio
    {
        public IEnumerable<Regimen> Consultar_Regimen();
    }
}
