using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public interface IClient
{
    public HubCallerContext Context { get; }
    public IHubCallerClients Clients { get; }
    public IClientProxy Caller { get; }
}