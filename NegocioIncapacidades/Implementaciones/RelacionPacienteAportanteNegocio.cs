using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class RelacionPacienteAportanteNegocio : IRelacionPacienteAportanteNegocio
    {
        private readonly IAccesoDatosDataWrite relacionpacienteaportanterepositorio;
        private readonly IAccesoDatosReadOnly relacionpacienteaportanteReadOnly;

        public RelacionPacienteAportanteNegocio(IAccesoDatosDataWrite relacionpacienteaportanteRepositorioIn, IAccesoDatosReadOnly relacionpacienteaportanteReadOnlyReposiorioIn)
        {
            relacionpacienteaportanterepositorio = relacionpacienteaportanteRepositorioIn;
            relacionpacienteaportanteReadOnly = relacionpacienteaportanteReadOnlyReposiorioIn;
        }

        public string NuevoRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante)
        {
            return relacionpacienteaportanterepositorio.InsertarRelacionPacienteAportante(relacionPacienteAportante).resultado;
        }

        public IList<RelacionPacienteAportante> Consultar_TodosRelacionPacienteAportante(string id_incapacidad)
        {
            return relacionpacienteaportanteReadOnly.Consultar_RelacionPacienteAportante(id_incapacidad);

        }


    }
}