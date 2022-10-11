using rps_server.Core.Model;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Repository.Game;

public class GameRepository : IGameRepository
{
    private Dictionary<string, IGame> _allGames = new Dictionary<string, IGame>();

    private readonly ILogger _logger;

    public GameRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddGame(IGame game)
    {
        _allGames.Add(game.GameId, game);
    }

    public bool TryGetGameById(string gameId, out IGame? game)
    {
        if (!_allGames.TryGetValue(gameId, out IGame? value))
        {
            game = null;
            return false;
        }

        game = value;
        return true;
    }

    public void RemoveGame(string gameId)
    {
        _allGames.Remove(gameId);
    }

    public IGame GetGameById(string gameId)
    {
        return _allGames[gameId];
    }
}