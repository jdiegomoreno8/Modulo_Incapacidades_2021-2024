using LibreriasParametros.Modelos;
using System.IO;

namespace ServiciosParametros
{
   public interface IGenerarIncapacidadPdfServicio
    {
        
        public MemoryStream GenerarPDF(Incapacidad incapacidad, string pathResources);
        

    }
}
