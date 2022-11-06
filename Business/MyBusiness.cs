using Microsoft.AspNetCore.SignalR;
using SignalRApi.Hubs;

namespace SignalRApi.Business;

public class MyBusiness
{
    readonly IHubContext<MyHub> _hubContext;

    public MyBusiness(IHubContext<MyHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessage(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
}
