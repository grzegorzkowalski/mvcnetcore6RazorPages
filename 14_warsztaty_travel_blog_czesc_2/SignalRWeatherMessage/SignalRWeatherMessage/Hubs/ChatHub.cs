using Microsoft.AspNetCore.SignalR;

namespace SignalRWeatherMessage.Hubs
{
    public class WeatherHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
