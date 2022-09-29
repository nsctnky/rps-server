using Microsoft.AspNetCore.SignalR;

namespace rps_server.Hubs;

public class GameHub : Hub
{
    private readonly IHubLayer _hubLayer;
    
    public GameHub(IHubLayer hubLayer)
    {
        _hubLayer = hubLayer;
    }

    public override Task OnConnectedAsync()
    {
        _hubLayer.OnConnected(Context, Clients);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _hubLayer.OnDisconnect(Context, Clients);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("auth")]
    public async Task OnAuth(string name, string id)
    {
        await _hubLayer.OnAuth(Context, Clients, name, id);
    }

    [HubMethodName("matchMake")]
    public async Task OnMatchMake(int gameType)
    {
        await _hubLayer.OnMatchMake(Context, Clients, gameType);
    }

    [HubMethodName("move")]
    public async Task OnMove(string gameId, int move)
    {
        await _hubLayer.OnMove(Context, Clients, gameId, move);
    }
}