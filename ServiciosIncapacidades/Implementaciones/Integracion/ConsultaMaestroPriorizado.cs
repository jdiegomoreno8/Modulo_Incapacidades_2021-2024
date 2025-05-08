using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;
using NegocioIncapacidades;
using System.Collections.Generic;

namespace ServiciosIncapacidades
{
    public class ConsultaMaestroPriorizadoServicio : IConsultaMaestroPriorizadoServicio
    {
        readonly IPacienteMaestroPriorizadoNegocio pacienteMaestroPriorizadoNegocio;
        public ConsultaMaestroPriorizadoServicio(IPacienteMaestroPriorizadoNegocio pacienteMaestroPriorizadoNegocioIn)
        {
            pacienteMaestroPriorizadoNegocio = pacienteMaestroPriorizadoNegocioIn;
        }

        public Paciente ConsultarPacienteMaestroPriorizado(Paciente pacienteABuscar)
        {
            var data = pacienteMaestroPriorizadoNegocio.ConsultarPacienteMaestroPriorizado(pacienteABuscar);

            Paciente paciente = new Paciente()
            {
                tipo_documento = data.tipo_identificacion,
                numero_documento = data.numero_identificacion,
                primer_nombre = data.primer_nombre,
                segundo_nombre = data.segundo_nombre,
                primer_apellido = data.primer_apellido,
                segundo_apellido = data.segundo_apellido,
                fecha_nacimiento = data.fecha_nacimiento,
                cod_depto_residencia = data.departamento_res,
                cod_mun_residencia = data.departamento_res + data.municipio_res,
                sexo = (data.sexo != null && data.sexo.Equals("F") ? "M" : data.sexo != null && data.sexo.Equals("M") ? "H" : "I")
            };

            RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud = new RelacionPacienteAfiliacionSalud()
            {
                id_incapacidad = "",
                id_paciente = 0,
                codigo_eps = data.Codigo_Entidad,
                tipo_afiliado = data.TipoAfiliado,
                estado = data.estado,
                regimen = data.Regimen,
                departamento_afil = data.departamento_afil,
                municipio_afil = data.municipio_afil,
                afiliado_PVS = data.MarcaPVS,
                fecha_inicio_contrato = data.FechaInicioContrato,
                fecha_fin_contrato = data.FechaFinalContrato,
                afiliado_INPEC = data.MarcaInpec,
                fecha_ingreso_inpec = data.FechaIngresoInpec,
                fecha_retiro_inpec = data.FechaRetiroInpec
            };

            paciente.relacionPacienteAfiliacionSalud = relacionPacienteAfiliacionSalud;

            //Aportante aportante1 = new Aportante()
            //{
            //    tipo_documento = "NIT",
            //    numero_documento = "820120120",
            //    razon_social = "Farmacia Centro",
            //    cod_depto = "",
            //    cod_municipio = "",
            //    correo_electronico = "",
            //    direccion = ""
            //};

            //Aportante aportante2 = new Aportante()
            //{
            //    tipo_documento = "NIT",
            //    numero_documento = "831121121",
            //    razon_social = "Farmacia Smart",
            //    cod_depto = "",
            //    cod_municipio = "",
            //    correo_electronico = "",
            //    direccion = ""
            //};

            //IList<Aportante> listaAportantes = new List<Aportante>
            //{
            //    aportante1,
            //    aportante2
            //};

            //RelacionPacienteAportante relacionPacienteAportante1 = new RelacionPacienteAportante()
            //{
            //    id_incapacidad = "",
            //    tipo_documento_pac = data.tipo_identificacion,
            //    numero_documento_pac = data.numero_identificacion,
            //    ultimo_periodo_salud = "2021",
            //    ultimo_periodo_afp_arl = "2021",
            //    cod_administradora_eps = "2021",
            //    cod_administradora_afp = "2021",
            //    cod_administradora_arl = "2021",
            //    IBC = 1,
            //    tipo_documento_ap = "NIT",
            //    numero_documento_ap = "820120120"
            //};

            //RelacionPacienteAportante relacionPacienteAportante2 = new RelacionPacienteAportante()
            //{
            //    id_incapacidad = "",
            //    tipo_documento_pac = data.tipo_identificacion,
            //    numero_documento_pac = data.numero_identificacion,
            //    ultimo_periodo_salud = "2022",
            //    ultimo_periodo_afp_arl = "2022",
            //    cod_administradora_eps = "2022",
            //    cod_administradora_afp = "2022",
            //    cod_administradora_arl = "2022",
            //    IBC = 1,
            //    tipo_documento_ap = "NIT",
            //    numero_documento_ap = "831121121"
            //};

            //IList<RelacionPacienteAportante> listaRelacionesPacienteAportante = new List<RelacionPacienteAportante>
            //{
            //    relacionPacienteAportante1,
            //    relacionPacienteAportante2
            //};

            //paciente.aportantes = listaAportantes;
            //paciente.relacionesPacienteAportante = listaRelacionesPacienteAportante;

            


            return paciente;

        }
    }
}
