using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace rps_server.Hubs;

public class GameHub : Hub
{
    private const string MessageReceived = "MessageReceived";
    private readonly IGameRepository _gameRepository;
    private readonly ILogging _logging;

    public GameHub(IGameRepository gameRepository, ILogging logging)
    {
        _gameRepository = gameRepository;
        _logging = logging;
    }

    public override Task OnConnectedAsync()
    {
        _logging.Info($"{Context.ConnectionId} has connected.");
        _gameRepository.AddConnected(Context, Clients);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logging.Info($"{Context.ConnectionId} has disconnected.");
        _gameRepository.RemoveConnected(Context);
        return base.OnDisconnectedAsync(exception);
    }

    [HubMethodName("auth")]
    public async Task OnAuth(string name, string id)
    {
        _logging.Info($"{Context.ConnectionId}, name: {name}, id: {id}");
        var jsonDict = new Dictionary<string, object>
        {
            {"command", "auth"},
            {"error", 0}
        };
        var json = JsonConvert.SerializeObject(jsonDict);
        await Clients.Caller.SendAsync(MessageReceived, json);
    }

    [HubMethodName("matchMake")]
    public async Task OnMatchMake()
    {
        var randomPlayer = _gameRepository.GetRandomPlayer(Context.ConnectionId);
        
        await randomPlayer.Caller.SendAsync(MessageReceived, "");
        await Clients.Caller.SendAsync(MessageReceived, "");
    }
}

public interface IGameRepository
{
    void AddConnected(HubCallerContext context, IHubCallerClients clients);
    void RemoveConnected(HubCallerContext context);
    IHubCallerClients GetRandomPlayer(string except);
}

public class GameRepository : IGameRepository
{
    private readonly ILogging _logging;
    private readonly Dictionary<HubCallerContext, IHubCallerClients> _idlePlayers = new Dictionary<HubCallerContext, IHubCallerClients>();

    public GameRepository(ILogging logging)
    {
        _logging = logging;
    }

    public void AddConnected(HubCallerContext context, IHubCallerClients clients)
    {
        _idlePlayers.Add(context, clients);
        _logging.Info($"add: {context.ConnectionId}");
    }

    public void RemoveConnected(HubCallerContext context)
    {
        _idlePlayers.Remove(context);
        _logging.Info($"remove: {context.ConnectionId}");
    }

    public IHubCallerClients GetRandomPlayer(string except)
    {
        foreach (var t in _idlePlayers)
        {
            if (t.Key.ConnectionId != except)
                return t.Value;
        }

        return null;
    }
}

public interface ILogging
{
    void Info(string msg);
}

public class DummyLogger : ILogging
{
    public void Info(string msg)
    {
        Console.WriteLine($"| INFO | {msg}");
    }
}