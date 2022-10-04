using rps_server.Core.Model;

namespace rps_server.Repository.Game;

public interface IGameRepository
{
    void AddGame(string gameId, IGame game);
    bool TryGetGameById(string gameId, out IGame? game);
    IGame GetGameById(string gameId);
}