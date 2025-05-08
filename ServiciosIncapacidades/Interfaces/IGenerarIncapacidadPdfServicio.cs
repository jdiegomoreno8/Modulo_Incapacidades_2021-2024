using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ServiciosIncapacidades
{
   public interface IGenerarIncapacidadPdfServicio
    {
        
        public MemoryStream GenerarPDF(Incapacidad incapacidad, string pathResources);
        

    }
}
