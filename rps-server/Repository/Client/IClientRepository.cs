using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;

namespace rps_server.Repository.Client;

public interface IClientRepository
{
    void AddClient(string connectionId, string uid, string name, IClientProxy caller);
    void AddClient(HubCallerContext context, string uid, string name, IClientProxy caller);
    void RemoveClientByUid(string uid);
    void RemoveClientByConnId(string connectionId);
    IClient GetClientByUid(string uid);
    IClient GetClientByConnId(string connectionId);
}