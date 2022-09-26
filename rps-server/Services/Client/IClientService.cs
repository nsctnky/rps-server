using Microsoft.AspNetCore.SignalR;

namespace rps_server.Services.Client;

public interface IClientService
{
    void AddClient(string connectionId, string uid, IClientProxy client);
    void RemoveClientByConnection(string connectionId);
    void RemoveClientByUid(string uid);
}