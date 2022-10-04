using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.Core.ServiceLocator;

namespace rps_server.Services.Client;

public interface IClientService : IService
{
    void AddClient(string connectionId, string uid, string name, IClientProxy client);
    void RemoveClientByConnection(string connectionId);
    void RemoveClientByUid(string uid);
    IClient GetByUid(string uid);
    IClient GetByConnection(string connectionId);
}