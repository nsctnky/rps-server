using rps_server.Core.Model;
using rps_server.Services.Client;
using rps_server.Services.Game;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Services.MatchMake;

public class MatchMakeService : IMatchMakeService
{
    private readonly IGameService _gameService;
    private readonly IClientService _clientService;
    private readonly ILogger? _logger;

    private readonly Queue<IClient> _waitingPlayers = new();
    private readonly Queue<IGame> _waitingGames = new();

    public MatchMakeService(ILogger logger, IGameService gameService, IClientService clientService)
    {
        _gameService = gameService;
        _clientService = clientService;
        _logger = logger;
    }

    public IGame GetMatch(string connectionId, int gameType)
    {
        IGame game = null;
        var client = _clientService.GetByConnection(connectionId);
        
        if (_waitingGames.Count > 0)
        {
            game = _waitingGames.Dequeue();
            game.SetPlayer(client);
        }
        else
        {
            game = new Core.Model.Game();
            game.SetGameId(GetRandomGameId());
            game.SetPlayer(client);
            _waitingGames.Enqueue(game);
        }
        
        return game;
    }

    public void AddClientToWaiting(string connectionId)
    {
        var client = _clientService.GetByConnection(connectionId);
        _waitingPlayers.Enqueue(client);
    }

    public string GetRandomGameId()
    {
        var rnd = new Random();
        return $"gm{rnd.Next(1, 100)}";
    }
}