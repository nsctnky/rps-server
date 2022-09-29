using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.Auth;
using rps_server.DTO.Response.Auth;
using rps_server.Services.Client;

namespace rps_server.Processors.Auth;

public class AuthProcessor : IAuthProcessor
{
    private readonly IClientService _clientService;

    public AuthProcessor(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    public IAuthResponse Process(HubCallerContext context, IClientProxy caller, IAuthRequest data)
    {
        _clientService.AddClient(context.ConnectionId, data.UserId, caller);
        return new AuthResponse(0, data.Name, data.UserId);
    }
}