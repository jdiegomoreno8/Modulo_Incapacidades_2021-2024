namespace ServiciosIncapacidades
{
    public class MedicoRethus
    {
        public MedicoRethus(string arg)
        {
            if (arg.Equals("test"))
            {
                TipoDocumento = "CC";
                NumeroDocumento = "1010";
                PrimerNombre = "Juan";
                SegundoNombre = "Carlos";
                PrimerApellido = "Perez";
                SegundoApellido = "Rojas";
                Sexo = "M";
                Encontrado = true;
                Estado = 1;
                
            }
        }

        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public bool Encontrado { get; set; }
        public string Sexo { get; set; }
        public int Estado { get; set; }

    }
  

}
