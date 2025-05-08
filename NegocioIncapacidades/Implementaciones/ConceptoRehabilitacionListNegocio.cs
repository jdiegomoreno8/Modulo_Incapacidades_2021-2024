using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
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
