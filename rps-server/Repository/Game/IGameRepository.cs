using rps_server.Core.Model;

namespace rps_server.Repository.Game;

public interface IGameRepository
{
    void AddGame(IGame game);
    bool TryGetGameById(string gameId, out IGame? game);
    void RemoveGame(string gameId);
    IGame GetGameById(string gameId);
}