using System;

namespace LibreriasParametros.Modelos.Incapacidades
{
   public class CausaAtencion
    {
        public int id_causa { get; set; }
        public string descripcion { get; set; }
        public int id_origen { get; set;  }
       public Boolean habilitado { get; set; }
    }
}
