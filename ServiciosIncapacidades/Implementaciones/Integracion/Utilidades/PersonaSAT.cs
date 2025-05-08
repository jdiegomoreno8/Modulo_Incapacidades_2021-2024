namespace ServiciosIncapacidades
{
    public class PersonaSAT
    {
        public PersonaSAT()
        {

        }
        
        public PersonaSAT(string arg)
        {
            if (arg.Equals("test"))
            {
                tipoDocumento = "CC";
                numeroDocumento = "123123123";
                primerNombre = "JJ";
                segundoNombre = "";
                primerApellido = "";
                segundoApellido = "TT";
                sexo = "M";
                estadoDocumentoAfiliado = "1";
                codigoEPS = "EPS002";
                estadoAfiliacionEPS = "A";
                tipoAfiliado = "A";
                regimen = "C";
                codigoAFP = "";
                estadoAfilliacionAFP = "";
                estado = 1;

                var afiliacionesARLTest = new AfiliacionesARL();
                afiliacionesARLTest.codigoARL = "14-30";
                afiliacionesARLTest.estadoAfilliacionARL = "1";
                afiliacionesARLTest.razonSocialAportante = "Empresa 1";
                afiliacionesARLTest.tipoDocumentoAportante = "NIT";
                afiliacionesARLTest.documentoAportante = 456456456;
                afiliacionesARLTest.emailAportante = "fernandojospina@gmail.com";

                var afiliacionesARLTest2 = new AfiliacionesARL();
                afiliacionesARLTest2.codigoARL = "14-23";
                afiliacionesARLTest2.estadoAfilliacionARL = "1";
                afiliacionesARLTest2.razonSocialAportante = "Empresa 2";
                afiliacionesARLTest2.tipoDocumentoAportante = "NIT";
                afiliacionesARLTest2.documentoAportante = 457457;
                afiliacionesARLTest2.emailAportante = "fernandojospina@gmail.com";

                afiliacionesARL = new AfiliacionesARL[2];
                afiliacionesARL[0] = afiliacionesARLTest;
                afiliacionesARL[1] = afiliacionesARLTest2;
            }
        }

        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string sexo { get; set; }
        public string estadoDocumentoAfiliado { get; set; }
        public string codigoEPS { get; set; }
        public string estadoAfiliacionEPS { get; set; }
        public string tipoAfiliado { get; set; }
        public string regimen { get; set; }
        public string codigoAFP { get; set; }
        public string estadoAfilliacionAFP { get; set; }
        public int estado { get; set; }

        public AfiliacionesARL[] afiliacionesARL { get;set; }

    }

    public class AfiliacionesARL
    {
        public string codigoARL { get; set; }
        public string estadoAfilliacionARL { get; set; }
        public string razonSocialAportante { get; set; }
        public string tipoDocumentoAportante { get; set; }
        public int documentoAportante { get; set; }
        public string emailAportante { get; set; }
    }

}
