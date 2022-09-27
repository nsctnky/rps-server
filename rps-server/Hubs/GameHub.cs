using Microsoft.AspNetCore.SignalR;
using rps_server.Response.Auth;
using rps_server.Response.MatchMake;
using rps_server.Response.Move;
using rps_server.Response.Result;
using rps_server.Services.Auth;
using rps_server.Services.Client;
using rps_server.Services.Game;
using rps_server.Services.MatchMake;
using rps_server.Services.Move;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Hubs;

public class GameHub : Hub
{
    private const string MessageReceived = "MessageReceived";
    private readonly ILogger _logging;

    private readonly IAuthService _authService;
    private readonly IClientService _clientService;
    private readonly IMatchMakeService _matchMakeService;
    private readonly IMoveService _moveService;
    private readonly IGameService _gameService;
    
    public GameHub(IAuthService authService, IClientService clientService, IMoveService moveService, 
        IMatchMakeService matchMakeService, IGameService gameService, ILogger logging)
    {
        _logging = logging;
        _authService = authService;
        _clientService = clientService;
        _matchMakeService = matchMakeService;
        _moveService = moveService;
        _gameService = gameService;
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
        IMoveResponse moveResponse = _moveService.GetMoveResponse(gameId, move, Context.ConnectionId);
        await Clients.Caller.SendAsync(MessageReceived, moveResponse.ToJson());

        if(!_gameService.IsGameFinished())
            return;
        
        IResultResponse resultResponse = _gameService.GetResultResponse();
        await Clients.Caller.SendAsync(MessageReceived, resultResponse.ToJson());
    }
}