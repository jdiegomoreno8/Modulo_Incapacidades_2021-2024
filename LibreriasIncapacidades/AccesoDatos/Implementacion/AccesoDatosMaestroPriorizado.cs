using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;
using System;
using System.Data;
using System.Linq;

namespace LibreriasIncapacidades.AccesoDatos
{
    public class AccesoDatosMaestroPriorizado : IAccesoDatosMaestroPriorizado
    {
        private readonly IConexionFactory ConexionFactory;
        private readonly IDapperWrapper DapperWrapper;

        public AccesoDatosMaestroPriorizado(IConexionFactory conexionFactoryIn, IDapperWrapper dapperWrapper)
        {
            ConexionFactory = conexionFactoryIn;
            DapperWrapper = dapperWrapper;
        }

        public MaestroPriorizado Consultar_Datos_Paciente(Paciente paciente)
        {
            object dataObject = new { };
            try
            {

                using (var connection = ConexionFactory.CrearConexion(EnumConexion.MaestroPriorizado))
                {
                    var query = DapperWrapper.Query<MaestroPriorizado>(connection, "dbo.Consultar_Persona_AfiliacionS",
                                         dataObject = new
                                         {
                                             tipo_documento = paciente.tipo_documento,
                                             numero_documento = paciente.numero_documento
                                         },
                                        commandType: CommandType.StoredProcedure);
                    return query.FirstOrDefault();
                };

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

    }
}
