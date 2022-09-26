using Microsoft.AspNetCore.SignalR;
using rps_server.Response.Auth;
using rps_server.Response.MatchMake;
using rps_server.Response.Model;
using rps_server.Response.Result;
using rps_server.Services.Auth;
using rps_server.Services.Client;
using rps_server.Services.MatchMake;
using ILogger = rps_server.Logger.ILogger;

namespace rps_server.Hubs;

public class GameHub : Hub
{
    private const string MessageReceived = "MessageReceived";
    private readonly ILogger _logging;

    private readonly IAuthService _authService;
    private readonly IClientService _clientService;
    private readonly IMatchMakeService _matchMakeService;
    
    public GameHub(IAuthService authService, IClientService clientService, IMatchMakeService matchMakeService, ILogger logging)
    {
        _logging = logging;
        _authService = authService;
        _clientService = clientService;
        _matchMakeService = matchMakeService;
    }

    public override Task OnConnectedAsync()
    {
        _logging.Info($"{Context.ConnectionId} has connected.");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logging.Info($"{Context.ConnectionId} has disconnected.");
        _clientService.RemoveClientByConnection(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("auth")]
    public async Task OnAuth(string name, string id)
    {
        // add client to onlines.
        _clientService.AddClient(Context.ConnectionId, id, Clients.Caller);
        
        // do auth stuff
        _logging.Info($"{Context.ConnectionId}, name: {name}, id: {id}");
        IAuthResponse auth = _authService.GetAuthResponse(id, name);
        await Clients.Caller.SendAsync(MessageReceived, auth.ToJson());
    }

    [HubMethodName("matchMake")]
    public async Task OnMatchMake(int gameType)
    {
        IMatchMakeResponse matchMake = _matchMakeService.GetMatchMakeResponse(gameType, Context.ConnectionId);
        await Clients.Caller.SendAsync(MessageReceived, matchMake.ToJson());
    }

    [HubMethodName("move")]
    public async Task OnMove(string gameId, int move)
    {
        // try add player movement to current game
        await Clients.Caller.SendAsync(MessageReceived, "success");

        // check game state, if it's finished, send game result
        var players = new List<IPlayerResult>
        {
            new PlayerResult("enes", "asd", 1),
            new PlayerResult("bot1", "bot1", 0)
        };
            
        var result = new ResultResponse(0, 1, players);
        await Clients.Caller.SendAsync(MessageReceived, result.ToJson());
    }
}