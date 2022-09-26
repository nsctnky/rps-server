using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public interface IClientRepository
{
    void AddClient(string connectionId, string uid, IClientProxy caller);
    void RemoveClientByUid(string uid);
    void RemoveClientByConnId(string connectionId);
    Model.IClient GetClientByUid(string uid);
    Model.IClient GetClientByConnId(string connectionId);
}