using Microsoft.AspNetCore.SignalR;
using rps_server.Services.Client;

namespace rps_server.Processors.Disconnect;

public class DisconnectProcessor : IDisconnectProcessor
{
    private readonly IClientService _clientService;
    
    public DisconnectProcessor(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    public void Process(HubCallerContext context, IClientProxy caller)
    {
        _clientService.RemoveClientByConnection(context.ConnectionId);
    }
}