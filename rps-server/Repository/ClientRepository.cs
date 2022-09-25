using Microsoft.AspNetCore.SignalR;
using ILogger = rps_server.Logger.ILogger;

namespace rps_server.Repository;

public class ClientRepository : IClientRepository
{
    private readonly ILogger _logger;
    private readonly Dictionary<HubCallerContext, IClient> _idlePlayers = new Dictionary<HubCallerContext, IClient>();

    public ClientRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddConnected(HubCallerContext context, IHubCallerClients clients)
    {
        _idlePlayers.Add(context, new Client(context, clients, clients.Caller));
        _logger.Info($"add: {context.ConnectionId}");
    }

    public void RemoveConnected(HubCallerContext context)
    {
        _idlePlayers.Remove(context);
        _logger.Info($"remove: {context.ConnectionId}");
    }

    public IClientProxy GetRandomPlayer(string except)
    {
        foreach (var t in _idlePlayers)
        {
            if (t.Key.ConnectionId != except)
                return t.Value.Caller;
        }

        return null;
    }

    public IHubCallerClients GetClients(HubCallerContext context)
    {
        if (!_idlePlayers.TryGetValue(context, out IClient client))
        {
            return null;
        }

        return client.Clients;
    }

    public IClientProxy GetCaller(HubCallerContext context)
    {
        if (!_idlePlayers.TryGetValue(context, out IClient client))
        {
            return null;
        }

        return client.Caller;
    }
}