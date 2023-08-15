using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using TaskSix_TagConvo.Client.Services.Interfaces;
using TaskSix_TagConvo.Shared.Model;

namespace TaskSix_TagConvo.Client.Services
{
    public class HubMessageClient : IHubMessageService
    {
        HubConnection? hubConnection;
        NavigationManager navigation;
        public event MessageRecieved? OnMessageRecieved;
        public HubMessageClient(NavigationManager navigation)
        {
            this.navigation=navigation;
        }

        public async Task Initialize()
        {
            if (hubConnection == null)
            {
                var uri = navigation.ToAbsoluteUri("/messageHub");
                hubConnection = new HubConnectionBuilder().WithUrl(uri).Build();
            }
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
            hubConnection.On<Message, string[]>("Message", (message, tags) =>
            {
                if (OnMessageRecieved!=null)
                    OnMessageRecieved.Invoke(message, tags);
            });
        }
    }
    public delegate Task MessageRecieved(Message msg, string[] tags);
}
