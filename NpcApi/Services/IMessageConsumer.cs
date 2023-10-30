namespace NpcApi.Services
{
    public interface IMessageConsumer
    {
        void StartListening();
        void StopListening();
    }
}