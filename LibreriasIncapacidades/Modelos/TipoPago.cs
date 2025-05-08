using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class TipoPago
    {
        public int id_tipo_pago { get; set; }
        public string descripcion { get; set; }
        public Boolean habilitado { get; set; }
    }
}
