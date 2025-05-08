using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class MotivaRetroactivaNegocio : IMotivaRetroactivaNegocio
    {
        readonly IAccesoDatosReadOnly motivaRetroactivaRepositorio;

        public MotivaRetroactivaNegocio(IAccesoDatosReadOnly motivaRetroactivaRepositorioIn)
        {
            motivaRetroactivaRepositorio = motivaRetroactivaRepositorioIn;
        }
        public IList<MotivaRetroactiva> Consultar_Todos_Motiva_Retroactiva()
        {
            return motivaRetroactivaRepositorio.Consultar_Motiva_Retroactiva();
        }



    }
}
