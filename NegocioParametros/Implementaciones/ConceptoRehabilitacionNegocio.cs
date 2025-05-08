using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace NegocioParametros
{
    public class ConceptoRehabilitacionNegocio : IConceptoRehabilitacionNegocio
    {
        readonly IAccesoDatosDataWrite incapacidadesrepositorioEscritura;
        readonly IAccesoDatosReadOnly incapacidadesRepositorioLectura;

        public ConceptoRehabilitacionNegocio(IAccesoDatosDataWrite ConceptoRehabilitacionrepositorioEscrituraIn, IAccesoDatosReadOnly ConceptoRehabilitacionRepositorioLecturaIn)
        {
            incapacidadesrepositorioEscritura = ConceptoRehabilitacionrepositorioEscrituraIn;
            incapacidadesRepositorioLectura = ConceptoRehabilitacionRepositorioLecturaIn;
        }
        public IList<IList<Incapacidad>> ConsultaIncapacidad(Paciente paciente)
        {
            var lista = incapacidadesRepositorioLectura.Consultar_Incapacidad_Concepto_Rehabilitacion(paciente);
            
            var groupedDiagnostico = lista.GroupBy(u => u.diagnostico_principal)
                .Select(grp => grp.ToList())
                .ToList();

            IList<IList<Incapacidad>> list = new List<IList<Incapacidad>>();

            foreach (var group  in groupedDiagnostico)
            {
                list.Add(group);
            }

            return list;
        }

        public RegistroConceptoRehabilitacion ConsultarCRPorPaciente(Paciente paciente)
        {
            return incapacidadesRepositorioLectura.Consultar_Concepto_Rehabilitacion_Por_Paciente(paciente);
        }

        public string RegistraConcepto(RegistroConceptoRehabilitacion concepto)
        {
            return incapacidadesrepositorioEscritura.regitrar_concepto_rehabilitacion(concepto).resultado;
        }
    }
}
