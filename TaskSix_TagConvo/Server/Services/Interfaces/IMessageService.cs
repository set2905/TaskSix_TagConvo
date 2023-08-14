namespace TaskSix_TagConvo.Server.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<(bool isSuccesful, string? message)> AddMessage(string message, string[] tagNames);
    }
}
