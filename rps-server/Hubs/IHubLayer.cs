using Microsoft.AspNetCore.SignalR;

namespace rps_server.Hubs;

public interface IHubLayer
{
    Task OnAuth(HubCallerContext context, IHubCallerClients clients, string name, string id);
    Task OnMatchMake(HubCallerContext context, IHubCallerClients clients, int gameType);
    Task OnMove(HubCallerContext context, IHubCallerClients clients, string gameId, int move);
    Task OnDisconnect(HubCallerContext context, IHubCallerClients clients);
    Task OnConnected(HubCallerContext context, IHubCallerClients clients);
}