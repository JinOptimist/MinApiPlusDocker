namespace CoolRpg.Services
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}