using rps_server.Core.Model;
using rps_server.DTO.Response.Model;
using rps_server.Services.Client;
using rps_server.Services.Game;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Services.MatchMake;

public class MatchMakeService : IMatchMakeService
{
    private readonly IGameService _gameService;
    private readonly IClientService _clientService;

    private readonly Dictionary<string, IPlayer> _waitingPlayers = new Dictionary<string, IPlayer>();

    public MatchMakeService(ILogger logger, IGameService gameService, IClientService clientService)
    {
        _gameService = gameService;
        _clientService = clientService;
    }

    public IGame GetMatch(string connectionId, int gameType)
    {
        // match make istenildikten sonra bunun bi cevabını döndür ve oyun aramaya başla bulunduktan
        // sonra ayrı bir response ile bunun cevabının dön, respon ismi match_join
        IGame game = new Core.Model.Game();
        game.SetGameId("asd");
        game.SetPlayer("bot", "bot", "bot");
        game.SetPlayer(connectionId, "test", "test");
        return game;
    }
}