using rps_server.Services.Game;

namespace rps_server.Repository.Game;

public interface IGameRepository
{
    void AddGame(string gameId, IGameService game);
    bool TryGetGameById(string gameId, out IGameService? game);
}