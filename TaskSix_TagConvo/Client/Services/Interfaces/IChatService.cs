namespace TaskSix_TagConvo.Client.Services.Interfaces
{
    public interface IChatService
    {
        public Task<bool> SendMessage(string message, string[] tags);

    }
}
