using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.Repository.Client;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Services.Client;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ILogger _logger;

    public ClientService(ILogger logger, IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
        _logger = logger;
    }

    public void AddClient(string connectionId, string uid, string name, IClientProxy client)
    {
        _clientRepository.AddClient(connectionId, uid, name, client);
    }

    public void RemoveClientByConnection(string connectionId)
    {
        var client = _clientRepository.GetClientByUid(connectionId);
        client.Disconnect();
        _clientRepository.RemoveClientByConnId(connectionId);
    }

    public void RemoveClientByUid(string uid)
    {
        _clientRepository.RemoveClientByUid(uid);
    }

    public IClient GetByUid(string uid)
    {
        return _clientRepository.GetClientByUid(uid);
    }

    public IClient GetByConnection(string connectionId)
    {
        return _clientRepository.GetClientByConnId(connectionId);
    }
}