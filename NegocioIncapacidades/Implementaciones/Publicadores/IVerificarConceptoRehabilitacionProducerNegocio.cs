namespace NegocioIncapacidades
{
    public interface IVerificarConceptoRehabilitacionProducerNegocio
    {
        void SendNotificationIncapacidadMessage<T>(T message);
    }
}