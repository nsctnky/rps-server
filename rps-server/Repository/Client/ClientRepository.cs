using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Repository.Client;

public class ClientRepository : IClientRepository
{
    private readonly ILogger _logger;
    private readonly Dictionary<string, IClient> _allClientsByUid = new();
    private readonly Dictionary<string, IClient> _allClientsByConnId = new();

    public ClientRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddClient(string connectionId, string uid, IClientProxy caller)
    {
        _allClientsByUid.Add(uid, new Core.Model.Client(connectionId, uid, caller));
        _allClientsByConnId.Add(connectionId, new Core.Model.Client(connectionId, uid, caller));
    }

    public void RemoveClientByUid(string uid)
    {
        if (!_allClientsByUid.TryGetValue(uid, out IClient client))
            return;

        _allClientsByUid.Remove(client.UserId);
        _allClientsByConnId.Remove(client.ConnectionId);
    }

    public void RemoveClientByConnId(string connectionId)
    {
        if (!_allClientsByConnId.TryGetValue(connectionId, out IClient client))
            return;

        _allClientsByUid.Remove(client.UserId);
        _allClientsByConnId.Remove(client.ConnectionId);
    }

    public IClient GetClientByUid(string uid)
    {
        return _allClientsByUid[uid];
    }

    public IClient GetClientByConnId(string connectionId)
    {
        return _allClientsByConnId[connectionId];
    }
}