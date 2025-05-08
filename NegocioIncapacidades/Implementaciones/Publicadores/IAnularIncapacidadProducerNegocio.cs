namespace NegocioIncapacidades
{
    public interface IAnularIncapacidadProducerNegocio
    {
        void SendNotificationAnularIncapacidadMessage<T>(T message);
    }
}