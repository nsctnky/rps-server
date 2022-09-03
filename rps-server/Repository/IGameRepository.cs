using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public interface IGameRepository
{
    void AddConnected(HubCallerContext context, IHubCallerClients clients);
    void RemoveConnected(HubCallerContext context);
    IHubCallerClients GetRandomPlayer(string except);
}