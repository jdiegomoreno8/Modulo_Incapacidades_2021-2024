namespace NegocioIncapacidades
{
    public interface IPagarIncapacidadProducerNegocio
    {
        void SendNotificationIncapacidadPagadaMessage<T>(T message);
    }
}