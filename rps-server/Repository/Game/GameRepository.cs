using rps_server.Services.Game;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Repository.Game;

public class GameRepository : IGameRepository
{
    private Dictionary<string, IGameService> _allGames = new Dictionary<string, IGameService>();

    private readonly ILogger _logger;

    public GameRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddGame(string gameId, IGameService game)
    {
        _allGames.Add(gameId, game);
    }

    public bool TryGetGameById(string gameId, out IGameService? game)
    {
        if (!_allGames.TryGetValue(gameId, out IGameService? value))
        {
            game = null;
            return false;
        }

        game = value;
        return true;
    }
}