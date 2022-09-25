using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public class Client : IClient
{
    public HubCallerContext Context { get; private set; }
    public IHubCallerClients Clients { get; private set; }
    public IClientProxy Caller { get; private set; }

    public Client(HubCallerContext context, IHubCallerClients clients, IClientProxy caller)
    {
        Context = context;
        Clients = clients;
        Caller = caller;
    }
}