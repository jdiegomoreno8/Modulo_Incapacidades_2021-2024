using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;

namespace NegocioParametros
{
   public class RelacionPacienteAfiliacionSaludNegocio : IRelacionPacienteAfiliacionSaludNegocio
    {
        readonly IAccesoDatosDataWrite relacionPacienteAfiliacionSaludRepositorio;
        readonly IAccesoDatosReadOnly relacionPacienteAfiliacionSaludReadOnlyRepositorio;


        public RelacionPacienteAfiliacionSaludNegocio(IAccesoDatosDataWrite relacionpacienteAfiliacionsaludrepositorioIn, IAccesoDatosReadOnly relacionPacienteAfiliacionSaludReadOnlyRepositorioIn)
        {
            relacionPacienteAfiliacionSaludRepositorio = relacionpacienteAfiliacionsaludrepositorioIn;
            relacionPacienteAfiliacionSaludReadOnlyRepositorio = relacionPacienteAfiliacionSaludReadOnlyRepositorioIn;
        }

        public string NuevoRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud)
        {
            return relacionPacienteAfiliacionSaludRepositorio.InsertarRelacionPacienteAfiliacionSalud(relacionPacienteAfiliacionSalud).resultado;
        }

        public RelacionPacienteAfiliacionSalud ConsultarRelacionPacienteAfiliacionSalud(long idPaciente)
        {
            return relacionPacienteAfiliacionSaludReadOnlyRepositorio.Consultar_RelacionPacienteAfiliacionSalud(idPaciente);
        }

    }
}
