using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return motivaRetroactivaRepositorio.Consultar_Motiva_Retroactiva();
            return (IList<MotivaRetroactiva>) motivaRetroactivaRepositorio.Consultar_Motiva_Retroactiva();
        }



    }
}
