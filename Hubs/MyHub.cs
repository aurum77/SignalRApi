using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs;

public class MyHub : Hub
{
    private static List<string> clients = new List<string>();

    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public override async Task OnConnectedAsync()
    {
        clients.Add(Context.ConnectionId);
        await Clients.All.SendAsync("Clients", clients);
        await Clients.All.SendAsync("UserJoined", Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        clients.Remove(Context.ConnectionId);
        await Clients.All.SendAsync("Clients", clients);
        await Clients.All.SendAsync("UserLeft", Context.ConnectionId);
    }
}
