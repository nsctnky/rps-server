namespace rps_server.Repository;

public interface IGameRepository
{
    void AddGame(string gameId, IGame game);
    bool TryGetGameById(string gameId, out IGame? game);
}