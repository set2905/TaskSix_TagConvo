namespace TaskSix_TagConvo.Client.Services.Interfaces
{
    public interface IHubMessageService
    {
        public Task Initialize();
        public event MessageRecieved? OnMessageRecieved;


    }
}
