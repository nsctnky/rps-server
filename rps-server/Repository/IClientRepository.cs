using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public interface IClientRepository
{
    void AddConnected(HubCallerContext context, IHubCallerClients clients);
    void RemoveConnected(HubCallerContext context);
    IClientProxy GetRandomPlayer(string except);
    IHubCallerClients GetClients(HubCallerContext context);
    IClientProxy GetCaller(HubCallerContext context);
}