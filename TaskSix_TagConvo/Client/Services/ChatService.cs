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
        public async Task<Message?> SendMessage(string message, string[] tags)
        {
            try
            {
                return await PostAsync<Message, SendMessageModel>("Chat/Send", new(message, tags));
            }
            catch (Exception ex)
            {
                snackbar.Add(ex.Message, Severity.Error);
                return null;
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
