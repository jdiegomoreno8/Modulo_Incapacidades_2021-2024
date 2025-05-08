using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;


namespace NegocioParametros
{
   public class RelacionPacienteAportanteNegocio : IRelacionPacienteAportanteNegocio
    {
        private readonly IAccesoDatosDataWrite relacionpacienteaportanterepositorio;

        public RelacionPacienteAportanteNegocio(IAccesoDatosDataWrite relacionpacienteaportanteRepositorioIn)
        {
            relacionpacienteaportanterepositorio = relacionpacienteaportanteRepositorioIn;
        }

        public string NuevoRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante)
        {
            return relacionpacienteaportanterepositorio.InsertarRelacionPacienteAportante(relacionPacienteAportante).resultado;
        }

    }
}
