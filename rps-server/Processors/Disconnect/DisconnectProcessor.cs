using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.Services.Client;
using rps_server.Services.Game;

namespace rps_server.Processors.Disconnect;

public class DisconnectProcessor : IDisconnectProcessor
{
    private readonly IClientService _clientService;

    public bool HasEndGameResult { get; private set; }
    public string GameId { get; private set; }

    public DisconnectProcessor(IClientService clientService)
    {
        _clientService = clientService;
    }

    public async Task Process(HubCallerContext context, IClientProxy caller)
    {
        IClient client = _clientService.GetByConnection(context.ConnectionId);
        _clientService.RemoveClientByConnection(context.ConnectionId);
        client.Disconnect();

        if (client.IsInGame && client.CurrentGame != null)
        {
            GameId = client.CurrentGame.GameId;
            HasEndGameResult = true;
            client.SetCurrentGame(null);
        }
    }
}