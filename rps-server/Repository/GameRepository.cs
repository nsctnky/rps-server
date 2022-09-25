using ILogger = rps_server.Logger.ILogger;

namespace rps_server.Repository;

public class GameRepository : IGameRepository
{
    private Dictionary<string, IGame> _allGames = new Dictionary<string, IGame>();

    private readonly ILogger _logger;

    public GameRepository(ILogger logger)
    {
        _logger = logger;
    }

    public void AddGame(string gameId, IGame game)
    {
        _allGames.Add(gameId, game);    
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
}