using Microsoft.AspNetCore.SignalR;
using ILogger = rps_server.Logger.ILogger;

namespace rps_server.Repository;

public class GameRepository : IGameRepository
{
    private readonly ILogger _logger;
    private readonly Dictionary<HubCallerContext, IHubCallerClients> _idlePlayers = new Dictionary<HubCallerContext, IHubCallerClients>();

    public GameRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddConnected(HubCallerContext context, IHubCallerClients clients)
    {
        _idlePlayers.Add(context, clients);
        _logger.Info($"add: {context.ConnectionId}");
    }

    public void RemoveConnected(HubCallerContext context)
    {
        _idlePlayers.Remove(context);
        _logger.Info($"remove: {context.ConnectionId}");
    }

    public IHubCallerClients GetRandomPlayer(string except)
    {
        foreach (var t in _idlePlayers)
        {
            if (t.Key.ConnectionId != except)
                return t.Value;
        }

        return null;
    }
}