using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
   public class CausaAtencion
    {
        public int id_causa { get; set; }
        public string descripcion { get; set; }
        public int id_origen { get; set;  }
       public Boolean habilitado { get; set; }
    }
}
