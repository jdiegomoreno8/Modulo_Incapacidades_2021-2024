namespace NegocioIncapacidades
{
    public interface IExpedirIncapacidadProducerNegocio
    {
        void SendNotificationIncapacidadMessage<T>(T message);
    }
}