using Microsoft.AspNetCore.SignalR;
using rps_server.Repository;
using rps_server.Response.Auth;
using rps_server.Response.MatchMake;
using rps_server.Response.Model;
using rps_server.Response.Result;
using ILogger = rps_server.Logger.ILogger;

namespace rps_server.Hubs;

public class GameHub : Hub
{
    private const string MessageReceived = "MessageReceived";
    private readonly IClientRepository _clientRepository;
    private readonly IGameRepository _gameRepository;
    private readonly ILogger _logging;

    public GameHub(IClientRepository clientRepository, IGameRepository gameRepository, ILogger logging)
    {
        _clientRepository = clientRepository;
        _gameRepository = gameRepository;
        _logging = logging;
    }

    public override Task OnConnectedAsync()
    {
        _logging.Info($"{Context.ConnectionId} has connected.");
        _clientRepository.AddConnected(Context, Clients);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logging.Info($"{Context.ConnectionId} has disconnected.");
        _clientRepository.RemoveConnected(Context);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("auth")]
    public async Task OnAuth(string name, string id)
    {
        _logging.Info($"{Context.ConnectionId}, name: {name}, id: {id}");
        IAuthResponse auth = new AuthResponse( 0, name, id);
        await Clients.Caller.SendAsync(MessageReceived, auth.ToJson());
    }

    [HubMethodName("matchMake")]
    public async Task OnMatchMake(int gameType)
    {
        var players = new List<IPlayer> { new Player("enes", "asd"), new Player("bot1", "bot1") };
        IMatchMakeResponse matchMake = new MatchMakeResponse(0, "zxc", players);
        await Clients.Caller.SendAsync(MessageReceived, matchMake.ToJson());
    }

    [HubMethodName("move")]
    public async Task OnMove(string gameId, int move)
    {
        var players = new List<IPlayer>
        {
            new Player("enes", "asd"),
            new Player("bot1", "bot1")
        };
            
        var result = new ResultResponse(0, 1, players);
        await Clients.Caller.SendAsync(MessageReceived, result.ToJson());
    }
}