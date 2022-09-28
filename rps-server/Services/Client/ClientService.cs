using Microsoft.AspNetCore.SignalR;
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

    public void AddClient(string connectionId, string uid, IClientProxy client)
    {
        _clientRepository.AddClient(connectionId, uid, client);
    }

    public void RemoveClientByConnection(string connectionId)
    {
        _clientRepository.RemoveClientByConnId(connectionId);
    }

    public void RemoveClientByUid(string uid)
    {
        _clientRepository.RemoveClientByUid(uid);
    }
}