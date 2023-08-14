using MudBlazor;
using TaskSix_TagConvo.Client.Services.Interfaces;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Client.Services
{
    public class ChatService : ClientAPIBase, IChatService
    {
        private readonly ISnackbar snackbar;

        public ChatService(HttpClient httpClient, ISnackbar snackbar) : base(httpClient)
        {
            this.snackbar = snackbar;
        }
        public async Task<bool> SendMessage(string message, string[] tags)
        {
            try
            {
                await PostAsync<SendMessageModel>("Chat/Send", new(message, tags));
                return true;
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
                return false;
            }
        }
        public async Task<List<Message>> GetFilteredMessages(Guid[] tagIds)
        {
            try
            {
                return await PostAsync<List<Message>, Guid[]>("Chat/Messages", tagIds)??new();
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
                return new();
            }
        }
        public async Task<List<Tag>> GetTags()
        {
            try
            {
                return await GetAsync<List<Tag>>("Chat/Tags")??new();
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
                return new();
            }
        }
    }
}
