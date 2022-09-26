using Microsoft.AspNetCore.SignalR;
using ILogger = rps_server.Logger.ILogger;

namespace rps_server.Repository;

public class ClientRepository : IClientRepository
{
    private readonly ILogger _logger;
    private readonly Dictionary<string, Model.IClient> _allClientsByUid = new();
    private readonly Dictionary<string, Model.IClient> _allClientsByConnId = new();

    public ClientRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddClient(string connectionId, string uid, IClientProxy caller)
    {
        _allClientsByUid.Add(uid, new Model.Client(connectionId, uid, caller));
        _allClientsByConnId.Add(connectionId, new Model.Client(connectionId, uid, caller));
    }

    public void RemoveClientByUid(string uid)
    {
        if(!_allClientsByUid.TryGetValue(uid, out Model.IClient client))
            return;

        _allClientsByUid.Remove(client.UserId);
        _allClientsByConnId.Remove(client.ConnectionId);
    }

    public void RemoveClientByConnId(string connectionId)
    {
        if(!_allClientsByConnId.TryGetValue(connectionId, out Model.IClient client))
            return;

        _allClientsByUid.Remove(client.UserId);
        _allClientsByConnId.Remove(client.ConnectionId);
    }

    public Model.IClient GetClientByUid(string uid)
    {
        return _allClientsByUid[uid];
    }

    public Model.IClient GetClientByConnId(string connectionId)
    {
        return _allClientsByConnId[connectionId];
    }
}