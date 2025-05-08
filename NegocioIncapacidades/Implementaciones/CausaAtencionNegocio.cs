using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class CausaAtencionNegocio : ICausaAtencionNegocio
    {
        readonly IAccesoDatosReadOnly causaAtencionRepositorio;

        public CausaAtencionNegocio(IAccesoDatosReadOnly causaAtencionRepositorioIn)
        {
            causaAtencionRepositorio = causaAtencionRepositorioIn;
        }
        public IList<CausaAtencion> Consultar_Todos_Causa_Motivo_Atencion()
        {
            return causaAtencionRepositorio.Consultar_Causa_Motivo_Atencion();
        }


    }
}
