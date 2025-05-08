using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace NegocioParametros
{
   public class ConceptoRehabilitacionListNegocio : IConceptoRehabilitacionListNegocio
    {
        readonly IAccesoDatosReadOnly conceptoRehabilitacionListRepositorio;

        public ConceptoRehabilitacionListNegocio(IAccesoDatosReadOnly conceptoRehabilitacionListRepositorioIn)
        {
            conceptoRehabilitacionListRepositorio = conceptoRehabilitacionListRepositorioIn;
        }

        public IList<Concepto_Rehabilitacion> Consultar_Todos_Conpceto_Rehabilitacion()
        {
            return conceptoRehabilitacionListRepositorio.Consultar_Concepto_Rehabilitacion();
        }

    }
}
