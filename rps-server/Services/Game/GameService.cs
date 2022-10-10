using rps_server.Core.Model;
using rps_server.Core.Utils.Constants;
using rps_server.Repository.Game;
using ILogger = rps_server.Core.Logger.ILogger;

namespace rps_server.Services.Game;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    public GameService(ILogger logger, IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public bool IsGameFinished(string gameId)
    {
        _gameRepository.TryGetGameById(gameId, out IGame game);
        return game.IsGameFinished;
    }

    public void SetMove(string connectionId, string gameId, MoveType move)
    {
        _gameRepository.TryGetGameById(gameId, out IGame game);
        game.SetMove(connectionId, move);
    }

    public Dictionary<IClient, KeyValuePair<MoveType, GameResult>> GetResultResponse(string gameId)
    {
        _gameRepository.TryGetGameById(gameId, out IGame game);
        return game.GetResult();
    }
}