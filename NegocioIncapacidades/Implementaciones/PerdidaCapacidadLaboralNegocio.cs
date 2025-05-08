using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiIncapacidades.Modelos.DTO;

namespace NegocioIncapacidades.Implementaciones
{
    public class PerdidaCapacidadLaboralNegocio: IPerdidaCapacidadLaboralNegocio
    {

        private readonly IAccesoDatosDataWrite perdidacapacidadlaboralrepositorio;
        private readonly IAccesoDatosReadOnly perdidacapacidadlaboralReadOnly;

        public PerdidaCapacidadLaboralNegocio(IAccesoDatosDataWrite perdidacapacidadlaboralRepositorioIn, IAccesoDatosReadOnly peridacapacidadlaboralReadOnlyReposiorioIn)
        {
            perdidacapacidadlaboralrepositorio = perdidacapacidadlaboralRepositorioIn;
            perdidacapacidadlaboralrepositorio = perdidacapacidadlaboralRepositorioIn;
            perdidacapacidadlaboralReadOnly = peridacapacidadlaboralReadOnlyReposiorioIn;
        }
        public IList<PerdidaCapacidadLaboral> Consultar_TodosPerdidaCapacidadLaboral(Int64 id_concepto_registro)
        {
            return perdidacapacidadlaboralReadOnly.Consultar_PerdidaCapacidadLaboral(id_concepto_registro);

        }

        public RespuestBD NuevaPerdidacCapacidadLaboral(PerdidaCapacidadLaboral pcl)
        {
            return perdidacapacidadlaboralrepositorio.InsertarPerdidaCapacidadLaboral(pcl);
        }
    }
}
